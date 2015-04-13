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
using DataApp.Core;

namespace ExpenseTracker.Website.Controllers
{
    public class CheckVouchersController : Controller
    {
        private DataAppFacade db = new DataAppFacade();
        private List<TransactionAccount> transactionAccounts = new List<TransactionAccount>();

        public CheckVouchersController()
        {
            this.transactionAccounts = db.TransactionAccountController.GetAll();
        }

        // GET: CheckVouchers
        public async Task<ActionResult> Index()
        {
            ViewBag.TransactionAccounts = this.transactionAccounts;
            if (Request["search"] != null)
            {
                string query = (string)Request["search"].ToLower();
                //return View(await db.CheckVouchers.Where(p => p.Notes.ToLower().Contains(query)).ToListAsync());
                return View(db.CheckVoucherController.Find(query));
            }

            //return View(await db.CheckVouchers.ToListAsync());
            return View( db.CheckVoucherController.GetAll());
        }

        // GET: CheckVouchers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckVoucher checkVoucher = db.CheckVoucherController.Get(c => c.Id == id); //await db.CheckVouchers.FindAsync(id);
            if (checkVoucher == null)
            {
                return HttpNotFound();
            }
            return View(checkVoucher);
        }

        // GET: CheckVouchers/Create
        public ActionResult Create()
        {
            ViewBag.PayeeId = new SelectList(this.transactionAccounts, "Id", "Name");
            return View();
        }

        // POST: CheckVouchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Amount,DueDate,EntryDate,CheckNo,VoucherNo,Notes,PayeeId")] CheckVoucher checkVoucher)
        {
            if (ModelState.IsValid)
            {
                db.CheckVoucherController.Add(checkVoucher);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PayeeId = new SelectList(this.transactionAccounts, "Id", "Name", checkVoucher.PayeeId);
            return View(checkVoucher);
        }

        // GET: CheckVouchers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckVoucher checkVoucher = this.db.CheckVoucherController.Get(c => c.Id == id); //await db.CheckVouchers.FindAsync(id);
            if (checkVoucher == null)
            {
                return HttpNotFound();
            }
            ViewBag.PayeeId = new SelectList(this.transactionAccounts, "Id", "Name", checkVoucher.PayeeId);
            return View(checkVoucher);
        }

        // POST: CheckVouchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Amount,DueDate,EntryDate,CheckNo,VoucherNo,Notes,PayeeId")] CheckVoucher checkVoucher)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(checkVoucher).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                db.CheckVoucherController.Update(checkVoucher);
                return RedirectToAction("Index");
            }
            ViewBag.PayeeId = new SelectList(this.transactionAccounts, "Id", "Name", checkVoucher.PayeeId);

            return View(checkVoucher);
        }

        // GET: CheckVouchers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckVoucher checkVoucher = this.db.CheckVoucherController.Get(c => c.Id == id); //await db.CheckVouchers.FindAsync(id);
            if (checkVoucher == null)
            {
                return HttpNotFound();
            }
            return View(checkVoucher);
        }

        // POST: CheckVouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //CheckVoucher checkVoucher = await db.CheckVouchers.FindAsync(id);
            //db.CheckVouchers.Remove(checkVoucher);
            //await db.SaveChangesAsync();
            this.db.CheckVoucherController.Delete(id);
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
