using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECOmaintainLOG.Controllers
{
    public class HomeController : Controller
    {
        private ECO_STICKEREntities db = new ECO_STICKEREntities();


        //[Authorize]
        public ActionResult Index(string vin, string status, string PcDateS, string PcDateE)
        {

            if (Session["UserID"] != null)
            {
                var data = db.SP_getTransaction_Log(vin, PcDateS, PcDateE, status);

                return View(data);
            }
            else {
                return RedirectToAction("Login", "Account");
            }
           
        }






        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}