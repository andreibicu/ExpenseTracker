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
    public class VouchersController : Controller
    {
        private DataAppContext db = new DataAppContext();

        // GET: Vouchers
        public async Task<ActionResult> Index()
        {
            return View(await db.Vouchers.ToListAsync());
        }

        // GET: Vouchers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voucher voucher = await db.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // GET: Vouchers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vouchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IsExpense,AddedOn,IssuedOn,Notes,TransactionAccountId")] Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                db.Vouchers.Add(voucher);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(voucher);
        }

        // GET: Vouchers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voucher voucher = await db.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // POST: Vouchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IsExpense,AddedOn,IssuedOn,Notes,TransactionAccountId")] Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voucher).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(voucher);
        }

        // GET: Vouchers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voucher voucher = await db.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // POST: Vouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Voucher voucher = await db.Vouchers.FindAsync(id);
            db.Vouchers.Remove(voucher);
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
