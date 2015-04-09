using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataApp.Core.DAL;
using DataApp.Core.Models;

namespace ExpenseTracker.Website.Controllers
{
    [Authorize]
    public class CheckTransactionsController : Controller
    {
        private DataAppContext db = new DataAppContext();

        // GET: CheckTransactions
        public async Task<ActionResult> Index()
        {
            var checkTransactions = db.CheckTransactions.Include(c => c.Check).Include(c => c.Voucher);
            List<TransactionAccount> accounts = db.TransactionAccounts.ToList();
            ViewBag.TransactionAccounts = accounts;
            if (Request["search"] != null)
            {
                string query = (string)Request["search"].ToLower();
                return View(await checkTransactions.Where(p => p.Notes.ToLower().Contains(query)).ToListAsync());
            }
            return View(await checkTransactions.ToListAsync());
        }

        // GET: CheckTransactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckTransaction checkTransaction = await db.CheckTransactions.FindAsync(id);
            if (checkTransaction == null)
            {
                return HttpNotFound();
            }
            return View(checkTransaction);
        }

        // GET: CheckTransactions/Create
        public ActionResult Create()
        {
            ViewBag.CheckId = new SelectList(db.Checks, "Id", "Notes");
            ViewBag.VoucherId = new SelectList(db.Vouchers, "Id", "Notes");
            return View();
        }

        // POST: CheckTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Amount,Notes,VoucherId,CheckId")] CheckTransaction checkTransaction)
        {
            if (ModelState.IsValid)
            {
                db.CheckTransactions.Add(checkTransaction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CheckId = new SelectList(db.Checks, "Id", "Notes", checkTransaction.CheckId);
            ViewBag.VoucherId = new SelectList(db.Vouchers, "Id", "Notes", checkTransaction.VoucherId);
            return View(checkTransaction);
        }

        // GET: CheckTransactions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckTransaction checkTransaction = await db.CheckTransactions.FindAsync(id);
            if (checkTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.CheckId = new SelectList(db.Checks, "Id", "Notes", checkTransaction.CheckId);
            ViewBag.VoucherId = new SelectList(db.Vouchers, "Id", "Notes", checkTransaction.VoucherId);
            return View(checkTransaction);
        }

        // POST: CheckTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Amount,Notes,VoucherId,CheckId")] CheckTransaction checkTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkTransaction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CheckId = new SelectList(db.Checks, "Id", "Notes", checkTransaction.CheckId);
            ViewBag.VoucherId = new SelectList(db.Vouchers, "Id", "Notes", checkTransaction.VoucherId);
            return View(checkTransaction);
        }

        // GET: CheckTransactions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckTransaction checkTransaction = await db.CheckTransactions.FindAsync(id);
            if (checkTransaction == null)
            {
                return HttpNotFound();
            }
            return View(checkTransaction);
        }

        // POST: CheckTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CheckTransaction checkTransaction = await db.CheckTransactions.FindAsync(id);
            db.CheckTransactions.Remove(checkTransaction);
            await db.SaveChangesAsync();
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
