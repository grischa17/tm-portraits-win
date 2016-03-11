using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;
using TuRM.Portrait.Models;

namespace TuRM.Portrait.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationDbContext db;

        public HomeController(IApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ActionResult> Index()
        {
            List<ViewModels.Product.Product> viewModels = new List<ViewModels.Product.Product>();
            IQueryable<ProductCategory> categories = db.ProductCategories.Where(w => w.Name == "Portrait");
            ProductCategory category;
            ViewModels.Product.Product viewModel;
            MapperConfiguration config;
            IMapper mapper;

            //init mapper
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ViewModels.Product.Product>()
                .ForMember(m => m.Image, opt => opt.MapFrom(src => src.Image == null ? null : new WebImage(src.Image)));
            });
            mapper = config.CreateMapper();

            if (categories.Count() == 0)
            {
                //Database is not initialized
                return View(viewModels);
            }

            category = categories.First();

            await db.LoadCollectionAsync(category, r => r.Products);

            foreach (var item in category.Products)
            {
                viewModel = mapper.Map<ViewModels.Product.Product>(item);
                viewModels.Add(viewModel);
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