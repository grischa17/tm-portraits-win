using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TuRM.Portrait.Models;

namespace TuRM.Portrait.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<ViewModels.Product.Product> viewModels = new List<ViewModels.Product.Product>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ProductCategory category = db.ProductCategories.Where(w => w.Name == "Portrait").First();
                ViewModels.Product.Product viewModel;
                MapperConfiguration config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Product, ViewModels.Product.Product>()
                    .ForMember(m => m.Image, opt => opt.MapFrom(src => src.Image == null ? null : new WebImage(src.Image)));
                });
                IMapper mapper = config.CreateMapper();

                await db.Entry(category).Collection(r => r.Products).LoadAsync();

                foreach (var item in category.Products)
                {
                    viewModel = mapper.Map<ViewModels.Product.Product>(item);
                    viewModels.Add(viewModel);
                }
            }

            return View(viewModels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        { 

            return View();
        }

        public ActionResult GTC()
        {

            return View();
        }

        public ActionResult Imprint()
        {

            return View();
        }
    }
}