using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace TuRM.Controllers
{
    public class EntityController<T,U> : Controller 
        where T : DbContext, new()
        where U : class
    {
        // GET: Entity
        public ActionResult Index()
        {
            T db = new T();

            return View(db.Set<U>().AsQueryable());
        }
    }
}