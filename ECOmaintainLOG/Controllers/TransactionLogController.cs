using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECOmaintainLOG;

namespace ECOmaintainLOG.Controllers
{
    public class TransactionLogController : Controller
    {
        private ECO_STICKEREntities db = new ECO_STICKEREntities();

        // GET: /TransactionLog/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Transaction_Log.ToList());
        }

        // GET: /TransactionLog/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Log transaction_log = db.Transaction_Log.Find(id);
            if (transaction_log == null)
            {
                return HttpNotFound();
            }
            return View(transaction_log);
        }

        // GET: /TransactionLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TransactionLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LogId,FileProcessName,XMLContent,ProcessDate,ConsoleMsg,Status,CreateDate,UpdateDate")] Transaction_Log transaction_log)
        {
            if (ModelState.IsValid)
            {
                db.Transaction_Log.Add(transaction_log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaction_log);
        }

        // GET: /TransactionLog/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Log transaction_log = db.Transaction_Log.Find(id);
            if (transaction_log == null)
            {
                return HttpNotFound();
            }
            return View(transaction_log);
        }

        // POST: /TransactionLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="LogId,FileProcessName,XMLContent,ProcessDate,ConsoleMsg,Status,CreateDate,UpdateDate")] Transaction_Log transaction_log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction_log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction_log);
        }

        // GET: /TransactionLog/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction_Log transaction_log = db.Transaction_Log.Find(id);
            if (transaction_log == null)
            {
                return HttpNotFound();
            }
            return View(transaction_log);
        }

        // POST: /TransactionLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Transaction_Log transaction_log = db.Transaction_Log.Find(id);
            db.Transaction_Log.Remove(transaction_log);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
