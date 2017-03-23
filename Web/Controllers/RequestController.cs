using AutoMapper;
using AutoMapper.QueryableExtensions;
using TuRM.Portrait.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace TuRM.Portrait.Controllers
{
    [RequireHttps]
    public class RequestController : Controller
    {
        // GET: Work
        [Authorize]
        public ActionResult Index()
        {
            ViewModels.Request.Index viewModel = new ViewModels.Request.Index();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                MapperConfiguration config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RequestHead, ViewModels.Request.Head>();
                });
                viewModel.Header = db.Database.SqlQuery<RequestHead>("select * from " + nameof(RequestHead) + "s "
                                                                        + "where Id not in (select " + nameof(RequestCancellation.RequestHeadId) + " from RequestCancellations)")
                                                                        .ToList()
                    .AsQueryable()
                    .ProjectTo<ViewModels.Request.Head>(config)
                    .ToList();
            }

            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Detail(int? Id, int? RequestItemId)
        {
            ViewModels.Request.Detail viewModel = new ViewModels.Request.Detail();
            RequestHead head;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                MapperConfiguration config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RequestHead, ViewModels.Request.Head>();
                    cfg.CreateMap<RequestItem, ViewModels.Request.Item>();
                    cfg.CreateMap<RequestImage, ViewModels.Request.Image>()
                        .ForMember(dest => dest.Data, opt => opt.MapFrom(src => new WebImage(src.Data))); ;
                });
                IMapper mapper = config.CreateMapper();

                if (RequestItemId.HasValue)
                {
                    Id = db.RequestItems.Where(w => w.Id == RequestItemId).Select(s => s.RequestHeadId).First();
                }

                head = db.RequestHeads.Where(w => w.Id == Id).First();
                viewModel.Head = mapper.Map<ViewModels.Request.Head>(head);

                db.Entry(head).Collection(c => c.RequestItems).Load();
                viewModel.Items = head.RequestItems.ToList().AsQueryable().ProjectTo<ViewModels.Request.Item>(config).ToList();

                db.Entry(head).Collection(c => c.RequestImages).Load();
                viewModel.Images = mapper.Map<List<ViewModels.Request.Image>>(head.RequestImages);

            }

            return View(viewModel);
        }

        [Authorize]
        public ActionResult ShowImage(int Id)
        {
            RequestImage image;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                image = db.RequestImages.Where(w => w.Id == Id).First();
            }

            return File(image.Data, new WebImage(image.Data).ImageFormat);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewModels.Request.Create viewModel;

            viewModel = new ViewModels.Request.Create();
            viewModel.Files = HttpContext.Session["Files"] as SortedList<string, WebImage> ?? new SortedList<string, WebImage>();
            viewModel.TotalAmount = 60;
            return View(viewModel);
        }

        private void loadAdjustments(Product product, ApplicationDbContext db, RequestHead head)
        {
            RequestItem item;

            db.Entry(product).Collection(p => p.PriceAdjustments).Load();
            for (int i = 0; i < product.PriceAdjustments?.Count; i++)
            {
                item = new RequestItem();
                item.RequestHeadId = head.Id;
                item.Amount = 1;
                item.Name = product.PriceAdjustments.ElementAt(i).Name;
                item.Price = product.PriceAdjustments.ElementAt(i).Adjustment;

                db.RequestItems.Add(item);
            }
        }

        public async Task<ActionResult> Create(ViewModels.Request.Create viewModel)
        {

            viewModel.Files = HttpContext.Session["Files"] as SortedList<string, WebImage> ?? new SortedList<string, WebImage>();

            HttpContext.Session["Files"] = null;

            await toDb(viewModel);

            RedirectToAction(nameof(Index));

            return View("CreateConfirm");
        }

        private string getBody(ViewModels.Request.Create viewModel)
        {
            StringBuilder builder = new StringBuilder();
            int price = 0;

            builder.AppendLine("<table style=\"border-style:solid;\"><tbody>");

            switch (viewModel.ProductId)
            {
                case 0:
                    builder.AppendLine($"<tr><td><b>Produkt:</b></td><td>Bleistiftporträt</td><td>60,00€</td></tr>");
                    price = 60;
                    break;

                case 1:
                    builder.AppendLine($"<tr><td><b>Produkt:</b></td><td>Buntstiftporträt</td><td>80,00€</td></tr>");
                    price = 80;
                    break;

                case 2:
                    builder.AppendLine($"<tr><td><b>Produkt:</b></td><td>Pastellporträt</td><td>100,00€</td></tr>");
                    price = 100;
                    break;

                default:
                    break;
            }

            switch (viewModel.SizeId)
            {
                case 0:
                    builder.AppendLine($"<tr><td><b>Größe:</b></td><td>A4</td><td>0,00€</td></tr>");
                    break;

                case 1:
                    builder.AppendLine($"<tr><td><b>Größe:</b></td><td>A3</td><td>30,00€</td></tr>");
                    price += 30;
                    break;

                case 2:
                    builder.AppendLine($"<tr><td><b>Größe:</b></td><td>A2</td><td>60,00€</td></tr>");
                    price += 60;
                    break;

                default:
                    break;
            }

            price += (viewModel.CountSubjects - 1) * 20;
            builder.AppendLine($"<tr><td><b>Anzahl Subjekte:</b></td><td>{viewModel.CountSubjects}</td><td>{(viewModel.CountSubjects - 1) * 20},00 €</td></tr>");
            builder.AppendLine($"<tr><td colspan=\"2\">Gesamt:</td><td>{price},00 €</td></tr></tbody></table>");

            builder.AppendLine($"<table style=\"border-style:solid;\"><tbody><tr><td>Name:</td><td>{viewModel.FirstName} {viewModel.LastName}</td></tr>");
            builder.AppendLine($"<tr><td>Adresse:</td><td>{viewModel.StreetPostOfficeBox} {viewModel.HouseNumber}</td></tr>");
            builder.AppendLine($"<tr><td></td><td>{viewModel.PostalCode} {viewModel.City}</td></tr>");
            builder.AppendLine($"<tr><td>Email:</td><td>{viewModel.Email}</td></tr>");
            builder.AppendLine($"<tr><td>Bemerkung:</td><td>{viewModel.Remarks}</td></tr></tbody></table>");

            return builder.ToString();
        }

        private async Task toDb(ViewModels.Request.Create viewModel)
        {
            int i = 0; 
            using (EmailDbContext db = new EmailDbContext())
            {
                OutBoxMail mail = new OutBoxMail();
                OutBoxAttachment attachment;

                mail.Body = getBody(viewModel);

                db.OutBox.Add(mail);

                await db.SaveChangesAsync();

                db.Entry(mail).Reload();
                
                foreach (var item in viewModel.Files)
                {
                    attachment = new OutBoxAttachment();

                    attachment.MailId = mail.Id;

                    attachment.Data = item.Value.GetBytes();
                    attachment.FileName = $"{(string.IsNullOrWhiteSpace(item.Value.FileName)? ("image" + (++i).ToString()) : item.Value.FileName)}.{item.Value.ImageFormat}";
                    attachment.MediaType = $"image/{item.Value.ImageFormat}";

                    db.OutBoxAttachments.Add(attachment);
                }
                
                await db.SaveChangesAsync();

            }

        }

        private void Client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            return;
        }

        [HttpPost]
        public void AddFile()
        {
            ViewModels.Request.Create viewModel = new ViewModels.Request.Create();
            HttpPostedFileBase file;

            viewModel.Files = HttpContext.Session["Files"] as SortedList<string, WebImage> ?? new SortedList<string, WebImage>();

            for (int i = 0; i < Request.Files.Count; i++)
            {
                file = Request.Files[i];
                if (viewModel.Files.ContainsKey(Request.Files.GetKey(i)))
                {
                    viewModel.Files[Request.Files.GetKey(i)] = new WebImage(file.InputStream);
                }
                else
                {
                    viewModel.Files.Add(Request.Files.GetKey(i), new WebImage(file.InputStream));
                }
            }

            HttpContext.Session["Files"] = viewModel.Files;

            //using (ApplicationDbContext db = new ApplicationDbContext())
            //{
            //    viewModel = new ViewModels.Request.Create(Product.Get(), Size.Get());
            //}

            //return View("FileList", viewModel.Files);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public void RemoveFile(string id)
        {
            ViewModels.Request.Create viewModel = new ViewModels.Request.Create();

            viewModel.Files = HttpContext.Session["Files"] as SortedList<string, WebImage> ?? new SortedList<string, WebImage>();

            viewModel.Files.Remove(id);

            HttpContext.Session["Files"] = viewModel.Files;

            //return View("Create", viewModel);
        }

    }
}