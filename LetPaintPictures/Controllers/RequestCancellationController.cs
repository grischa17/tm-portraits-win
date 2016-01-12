using LetPaintPictures.Models;
using System.Web.Mvc;

namespace LetPaintPictures.Controllers
{
    [Authorize]
    public class RequestCancellationController : Controller
    {

        public ActionResult Create(int RequestId, string CancelReason)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                RequestCancellation cancellation = new RequestCancellation();

                cancellation.RequestHeadId = RequestId;
                cancellation.Reason = CancelReason;

                db.RequestCancellations.Add(cancellation);
                db.SaveChanges();
            }

            return View();
        }
    }
}