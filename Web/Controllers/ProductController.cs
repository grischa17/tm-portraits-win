﻿using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TuRM.Portrait.Models;

namespace TuRM.Portrait.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product

        [RequireHttps]
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

            return View(viewModels.AsEnumerable());
        }

        [AllowAnonymous]
        public ActionResult ShowImage(int Id)
        {
            Product image;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                image = db.Products.Where(w => w.Id == Id).First();
            }

            return File(image.Image, new WebImage(image.Image).ImageFormat);
        }

        [RequireHttps]
        public ActionResult Detail(int Id)
        {
            ViewModels.Product.Product viewModel;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Product product = db.Products.Where(w => w.Id == Id).First();
                MapperConfiguration config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Product, ViewModels.Product.Product>()
                    .ForMember(m => m.Image, opt => opt.MapFrom(src => src.Image == null ? null : new WebImage(src.Image)));
                });
                IMapper mapper = config.CreateMapper();

                viewModel = mapper.Map<ViewModels.Product.Product>(product);
            }

            return View(viewModel);
        }

        [HttpGet]
        [RequireHttps]
        public ActionResult Edit(int Id)
        {
            ViewModels.Product.Product viewModel;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Product product = db.Products.Where(w => w.Id == Id).First();
                MapperConfiguration config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Product, ViewModels.Product.Product>()
                    .ForMember(m => m.Image, opt => opt.MapFrom(src => src.Image == null ? null : new WebImage(src.Image)));
                });
                IMapper mapper = config.CreateMapper();

                viewModel = mapper.Map<ViewModels.Product.Product>(product);
            }

            return View(viewModel);
        }

        [HttpPost]
        [RequireHttps]
        public async Task<ActionResult> Edit(ViewModels.Product.Product viewModel)
        {
            if (viewModel.DisplayWidth == 0)
            {
                ModelState.AddModelError(nameof(viewModel.DisplayWidth), "Geben Sie die Anzeige-Breite ein");
            }
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    Product productDb = db.Products.Where(w => w.Id == viewModel.Id).First(), product;
                    WebImage image;
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ViewModels.Product.Product, Product>()
                        .ForMember(m => m.Image, opt => opt.Ignore());
                    });
                    IMapper mapper = config.CreateMapper();
                    
                    if (productDb.Image == null && Request.Files["ImageUpload"] == null)
                    {
                        ModelState.AddModelError(nameof(viewModel.Image), "Laden Sie ein Bild hoch");
                        return View(viewModel);
                    }

                    product = mapper.Map<Product>(viewModel);
                    image = WebImage.GetImageFromRequest("ImageUpload");
                    product.Image = image == null ? productDb.Image : image.GetBytes();

                    db.Entry(productDb).CurrentValues.SetValues(product);

                    await db.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Detail), "Product",  new { Id = viewModel.Id });
            }

            return View(viewModel);
        }

        [HttpGet]
        [RequireHttps]
        public ActionResult Create()
        {
            return View(new ViewModels.Product.Product());
        }

        [HttpPost]
        [RequireHttps]
        public async Task<ActionResult> Create(ViewModels.Product.Product viewModel)
        {
                    Product product;

            if (viewModel.DisplayWidth == 0)
            {
                ModelState.AddModelError(nameof(viewModel.DisplayWidth), "Geben Sie die Anzeige-Breite ein");
            }
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    WebImage image;
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ViewModels.Product.Product, Product>()
                        .ForMember(m => m.Image, opt => opt.Ignore())
                        .ForMember(m => m.ProductCategoryId, opt => opt.UseValue(1));
                    });
                    IMapper mapper = config.CreateMapper();

                    if (Request.Files["ImageUpload"] == null)
                    {
                        ModelState.AddModelError(nameof(viewModel.Image), "Laden Sie ein Bild hoch");
                        return View(viewModel);
                    }

                    product = mapper.Map<Product>(viewModel);
                    image = WebImage.GetImageFromRequest("ImageUpload");
                    product.Image = image.GetBytes();

                    db.Products.Add(product);

                    await db.SaveChangesAsync();

                    await db.Entry(product).ReloadAsync();
                }

                return RedirectToAction(nameof(Detail), "Product", new { Id = product.Id });
            }

            return View(viewModel);
        }
    }
}