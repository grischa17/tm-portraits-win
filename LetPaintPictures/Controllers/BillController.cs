using AutoMapper;
using AutoMapper.QueryableExtensions;
using LetPaintPictures.Models;
using LetPaintPictures.ViewModels.Bill;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LetPaintPictures.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        [HttpGet]
        public ActionResult Create(int? requestId)
        {
            ViewModels.Bill.Create viewModel = new ViewModels.Bill.Create();
            List<RequestItem> items;

            if (requestId.HasValue)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    viewModel.Head = Mapper.Map<Head>(db.RequestHeads.Where(w => w.Id == requestId).First());
                    items = db.RequestItems.Where(w => w.RequestHeadId == viewModel.Head.RequestHeadId).ToList();
                    viewModel.Items = items.AsQueryable().ProjectTo<Item>().ToList();
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Create viewModel)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    BillHead head = Mapper.Map<BillHead>(viewModel.Head);
                    List<BillItem> items;

                    db.BillHeads.Add(head);

                    db.SaveChanges();

                    db.Entry(head).Reload();
                    viewModel.Head.Id = head.Id;

                    items = viewModel.Items.AsQueryable().ProjectTo<BillItem>().ToList();

                    foreach (var item in items)
                    {
                        item.HeadId = head.Id;
                    }
                    db.BillItems.AddRange(items);
                    db.SaveChanges();

                    db.Entry(head).Collection(n => n.Items).Load();
                    viewModel.Items = head.Items.AsQueryable().ProjectTo<Item>().ToList();
                }

                return View("Detail", Mapper.Map<Detail>(viewModel));
            }

            return View(viewModel);
        }

        public ActionResult Detail(int Id)
        {
            Detail detail = new Detail();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                detail.Head = Mapper.Map<Head>(db.BillHeads.Where(w => w.Id == Id).First());
                detail.Items = db.BillItems.Where(w => w.HeadId == Id).ProjectTo<Item>().ToList();
            }
            return View(detail);
        }

        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                IQueryable<BillHead> heads = db.BillHeads.OrderByDescending(o => o.CreatedOn);

                return View(heads.ProjectTo<Head>().ToList());
            }
        }
    }
}