using System.Web.Mvc;
using TuRM.Common.Controllers;
using TuRM.User.Models;

namespace TuRM.User.Controllers
{
    public class UserController : EntityController<UserStoreDbContext, Models.User>
    {
        // GET: User
        public override ActionResult Index()
        {
            return base.Index();
        }
    }
}