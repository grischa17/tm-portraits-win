using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace TuRM.Common.Controllers
{
    public class EntityController<T,U> : Controller 
        where T : DbContext, new()
        where U : class
    {
        // GET: Entity
        public virtual ActionResult Index()
        {
            ViewModels.Entity.Index viewModel = new ViewModels.Entity.Index();
            T db = new T();
            Type type;
            DisplayAttribute displayAttribute;
            PropertyInfo property;

            type = typeof(U);
            viewModel.Collumns = type.GetProperties().Where(w => w.CanRead && w.GetMethod != null && w.PropertyType.Namespace != "System.Collections.Generic").AsQueryable();
            viewModel.Rows = db.Set<U>().AsEnumerable();

            type = typeof(T);
            property = type.GetProperties().Where(w => w.PropertyType == typeof(DbSet<U>)).Single();
            displayAttribute = property.PropertyType.GetCustomAttribute<DisplayAttribute>();
            viewModel.Name = displayAttribute == null ? property.Name : displayAttribute.Name;

            return View("~/Views/Entity/Index.cshtml", viewModel);
        }
    }
}