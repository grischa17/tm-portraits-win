using AutoMapper;
using LetPaintPictures.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LetPaintPictures
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.CreateMap<ViewModels.Request.Create, RequestHead>();

            Mapper.CreateMap<Product, ViewModels.Product>();

            Mapper.CreateMap<RequestHead, ViewModels.Request.Head>();
            Mapper.CreateMap<RequestHead, ViewModels.Bill.Head>()
                .ForMember(dest => dest.RequestHeadId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            Mapper.CreateMap<RequestItem, ViewModels.Request.Item>();
            Mapper.CreateMap<RequestItem, ViewModels.Bill.Item>()
                .ForMember(dest => dest.RequestItemId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            Mapper.CreateMap<RequestImage, ViewModels.Request.Image>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => new WebImage(src.Data)));

            Mapper.CreateMap<ViewModels.Bill.Head, BillHead>();
            Mapper.CreateMap<ViewModels.Bill.Item, BillItem>()
                .ForMember(m => m.BillHead, o => o.Ignore());

            Mapper.CreateMap<ViewModels.Bill.Create, ViewModels.Bill.Detail>();

            Mapper.CreateMap<BillHead, ViewModels.Bill.Head>();
            Mapper.CreateMap<BillItem, ViewModels.Bill.Item>();

            //Mapper.CreateMap<ApplicationUser, IdentityUser>()
            //    .ForMember(dest => dest.Claims, opt => opt.Ignore());
        }
    }
}
