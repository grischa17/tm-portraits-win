using AutoMapper;
using AutoMapper.QueryableExtensions;
using TuRM.Portrait.Models;
using TuRM.Portrait.ViewModels.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace TuRM.Portrait.Controllers
{
    [RequireHttps]
    [Authorize]
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
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<RequestHead, Head>()
                            .ForMember(m => m.CreatedOn, opt => opt.UseValue(DateTime.Now))
                            .ForMember(dest => dest.RequestHeadId, opt => opt.MapFrom(src => src.Id));
                        cfg.CreateMap<RequestItem, Item>()
                            .ForMember(dest => dest.RequestItemId, opt => opt.MapFrom(src => src.Id))
                            .ForMember(dest => dest.Id, opt => opt.Ignore());
                    });
                    IMapper mapper = config.CreateMapper();

                    viewModel.Head = mapper.Map<Head>(db.RequestHeads.Where(w => w.Id == requestId).First());
                    items = db.RequestItems.Where(w => w.RequestHeadId == viewModel.Head.RequestHeadId).ToList();
                    viewModel.Items = items.AsQueryable().ProjectTo<Item>(config).ToList();
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Create viewModel)
        {
            if (ModelState.IsValid)
            {
                MapperConfiguration config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Head, BillHead>()
                        .ForMember(m => m.CreatedOn, opt => opt.UseValue<DateTime>(DateTime.Now));
                    cfg.CreateMap<Item, BillItem>();
                    cfg.CreateMap<BillItem, Item>();
                    cfg.CreateMap<Create, Detail>();
                });
                IMapper mapper = config.CreateMapper();

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    BillHead head = mapper.Map<BillHead>(viewModel.Head);
                    List<BillItem> items;

                    db.BillHeads.Add(head);

                    db.SaveChanges();

                    db.Entry(head).Reload();
                    viewModel.Head.Id = head.Id;

                    items = viewModel.Items.AsQueryable().ProjectTo<BillItem>(config).ToList();

                    foreach (var item in items)
                    {
                        item.HeadId = head.Id;
                    }
                    db.BillItems.AddRange(items);
                    db.SaveChanges();

                    db.Entry(head).Collection(n => n.BillItems).Load();
                    viewModel.Items = head.BillItems.AsQueryable().ProjectTo<Item>(config).ToList();
                }

                return View("Detail", mapper.Map<Detail>(viewModel));
            }

            return View(viewModel);
        }

        public ActionResult Detail(int Id)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BillHead, Head>();
                cfg.CreateMap<BillItem, Item>();
            });
            IMapper mapper = config.CreateMapper();
            Detail detail = new Detail();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                detail.Head = mapper.Map<Head>(db.BillHeads.Where(w => w.Id == Id).First());
                detail.Items = db.BillItems.Where(w => w.HeadId == Id).ProjectTo<Item>(config).ToList();
            }
            return View(detail);
        }

        public ActionResult Index()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BillHead, Head>();
            });

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<BillHead> heads = db.Database.SqlQuery<BillHead>("select * from " + nameof(BillHead) + "s "
                                                                        + "where Id not in (select " + nameof(BillCancellation.Id) + " from " + nameof(BillCancellation) + "s)").AsQueryable().OrderByDescending(o => o.CreatedOn).ToList();

                return View(heads.AsQueryable().ProjectTo<Head>(config).ToList());
            }
        }
    }
}