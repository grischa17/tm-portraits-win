using System.Web.Mvc;
using TuRM.Controllers;
using TuRM.User.Models;

namespace TuRM.User.Controllers
{
    [RouteArea("User")]
    public class UserController : EntityController<ApplicationDbContext, ApplicationUser>
    {
        // GET: User
        //public ActionResult Index()
        //{
        //    ApplicationDbContext db;

        //    db.Set<ApplicationUser>();
        //    return View();
        //}
    }
}