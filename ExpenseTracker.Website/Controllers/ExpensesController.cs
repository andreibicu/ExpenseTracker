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
    public class ExpensesController : Controller
    {
        private DataAppContext db = new DataAppContext();

        // GET: Expenses
        public async Task<ActionResult> Index()
        {
            var expenses = db.Expenses.Include(e => e.Voucher);

            if (Request["search"] != null)
            {
                string query = (string)Request["search"].ToLower();
                return View(await expenses.Where(p => p.Notes.ToLower().Contains(query)).ToListAsync());
            }

            return View(await expenses.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            ViewBag.VoucherId = new SelectList(db.Vouchers, "Id", "Notes");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Notes,VoucherId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.VoucherId = new SelectList(db.Vouchers, "Id", "Notes", expense.VoucherId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.VoucherId = new SelectList(db.Vouchers, "Id", "Notes", expense.VoucherId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Notes,VoucherId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.VoucherId = new SelectList(db.Vouchers, "Id", "Notes", expense.VoucherId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Expense expense = await db.Expenses.FindAsync(id);
            db.Expenses.Remove(expense);
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
