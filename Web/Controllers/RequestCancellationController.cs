using LetPaintPictures.Models;
using System.Collections.Generic;
using System.Linq;
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
                List<BillHead> bills;

                cancellation.RequestHeadId = RequestId;
                cancellation.Reason = CancelReason;

                bills = db.BillHeads.Where(w => w.RequestHeadId == RequestId).ToList();

                foreach (var bill in bills)
                {
                    db.Entry(bill).Reference(r => r.BillCancellation).Load();
                    if (bill.BillCancellation == null)
                    {
                        db.BillCancellations.Add(new BillCancellation() { Id = bill.Id, Reason = CancelReason });
                    }
                }
                db.SaveChanges();

                db.RequestCancellations.Add(cancellation);
                db.SaveChanges();
            }

            return View();
        }
    }
}