using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Threading.Tasks;
using TuRM.Portrait.Test.Models;
using Autofac;
using Autofac.Integration.Mvc;

namespace TuRM.Portrait.Test
{
    [TestClass]
    public class HomeController
    {
        //private IContainer container;

        [TestInitialize]
        public void Init()
        {
        //    var builder = new ContainerBuilder();

        //    // Register dependencies in controllers
        //    builder.RegisterType<Controllers.HomeController>()
        //        .WithParameter(new TypedParameter(typeof(Portrait.Models.IApplicationDbContext), new ApplicationDbContext())).AsSelf();

            //// Register dependencies in filter attributes
            //builder.RegisterFilterProvider();

            //// Register dependencies in custom views
            //builder.RegisterSource(new ViewRegistrationSource());

            //// Register our Data dependencies
            //builder.RegisterModule(new Other.DataModule<ApplicationDbContext>());

            //container = builder.Build();

            //// Set MVC DI resolver to use our Autofac container
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
        }

        /// <summary>
        /// Bei dem initialen Start bricht die Anwendung sofort ab, weil es keine Produktkategorien hat
        /// -> Die Anwendung sollte ohne Abbruch durchlaufen
        /// </summary>
        [TestMethod]
        public async Task Index69()
        {
            var builder = new ContainerBuilder();
            ApplicationDbContext memory = new ApplicationDbContext();
            IContainer container;
            Controllers.HomeController controller;

            // Register dependencies in controllers
            builder.RegisterType<Controllers.HomeController>()
                .WithParameter(new TypedParameter(typeof(Portrait.Models.IApplicationDbContext), memory)).AsSelf();
            container = builder.Build();

            controller = container.Resolve<Controllers.HomeController>();

            //Arrange
            memory.ProductCategories = new List<Portrait.Models.ProductCategory>().AsQueryable();


            //Act
            var result = ((await controller.Index() as ViewResult).Model) as List<ViewModels.Product.Product>;

            ////Assert
            //Assert.AreEqual(result.Count, 3);
            //Assert.AreEqual("US", result[0].Name);
            //Assert.AreEqual("India", result[1].Name);
            //Assert.AreEqual("Russia", result[2].Name);
        }

        [TestMethod]
        public async Task Index69_1()
        {
            var builder = new ContainerBuilder();
            ApplicationDbContext memory = new ApplicationDbContext();
            IContainer container;
            Controllers.HomeController controller;

            // Register dependencies in controllers
            builder.RegisterType<Controllers.HomeController>()
                .WithParameter(new TypedParameter(typeof(Portrait.Models.IApplicationDbContext), memory)).AsSelf();
            container = builder.Build();

            controller = container.Resolve<Controllers.HomeController>();

            //Arrange
            memory.ProductCategories = new List<Portrait.Models.ProductCategory>() { new Portrait.Models.ProductCategory() {  Id = 1, Name = "Portrait" } }.AsQueryable();


            //Act
            var result = ((await controller.Index() as ViewResult).Model) as List<ViewModels.Product.Product>;

            ////Assert
            //Assert.AreEqual(result.Count, 3);
            //Assert.AreEqual("US", result[0].Name);
            //Assert.AreEqual("India", result[1].Name);
            //Assert.AreEqual("Russia", result[2].Name);
        }
    }
}
