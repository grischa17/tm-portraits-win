using LetPaintPictures.Models;
using System.Web.Mvc;

namespace LetPaintPictures.Controllers
{
    [RequireHttps]
    [Authorize]
    public class BillCancellationController : Controller
    {

        public ActionResult Create(int BillId, string CancelReason)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                BillCancellation cancellation = new BillCancellation();

                cancellation.Id = BillId;
                cancellation.Reason = CancelReason;

                db.BillCancellations.Add(cancellation);
                db.SaveChanges();
            }

            return View();
        }
    }
}