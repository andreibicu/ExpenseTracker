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
    public class ExpenseItemsController : Controller
    {
        private DataAppContext db = new DataAppContext();

        // GET: ExpenseItems
        public async Task<ActionResult> Index()
        {
            var expenseItems = db.ExpenseItems.Include(e => e.Expense).Include(e => e.Project);
            List<TransactionAccount> accounts = db.TransactionAccounts.ToList();
            ViewBag.TransactionAccounts = accounts;
            if (Request["search"] != null)
            {
                string query = (string)Request["search"].ToLower();
                return View(await expenseItems.Where(p => p.Notes.ToLower().Contains(query)).ToListAsync());
            }
            return View(await expenseItems.ToListAsync());
        }

        // GET: ExpenseItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = await db.ExpenseItems.FindAsync(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            return View(expenseItem);
        }

        // GET: ExpenseItems/Create
        public ActionResult Create()
        {
            ViewBag.ExpenseId = new SelectList(db.Expenses, "Id", "Id");
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.TransactionAccountId = new SelectList(db.TransactionAccounts, "Id", "Name");

            return View();
        }

        // POST: ExpenseItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PurchaseDate,Notes,ORNumber,Amount,Category,ExpenseId,TransactionAccountId,ProjectId")] ExpenseItem expenseItem)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseItems.Add(expenseItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExpenseId = new SelectList(db.Expenses, "Id", "Id", expenseItem.ExpenseId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", expenseItem.ProjectId);
            ViewBag.TransactionAccountId = new SelectList(db.TransactionAccounts, "Id", "Name");

            return View(expenseItem);
        }

        // GET: ExpenseItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = await db.ExpenseItems.FindAsync(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpenseId = new SelectList(db.Expenses, "Id", "Id", expenseItem.ExpenseId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", expenseItem.ProjectId);
            ViewBag.TransactionAccountId = new SelectList(db.TransactionAccounts, "Id", "Name");

            return View(expenseItem);
        }

        // POST: ExpenseItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PurchaseDate,Notes,ORNumber,Amount,Category,ExpenseId,TransactionAccountId,ProjectId")] ExpenseItem expenseItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExpenseId = new SelectList(db.Expenses, "Id", "Id", expenseItem.ExpenseId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", expenseItem.ProjectId);
            ViewBag.TransactionAccountId = new SelectList(db.TransactionAccounts, "Id", "Name");

            return View(expenseItem);
        }

        // GET: ExpenseItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseItem expenseItem = await db.ExpenseItems.FindAsync(id);
            if (expenseItem == null)
            {
                return HttpNotFound();
            }
            return View(expenseItem);
        }

        // POST: ExpenseItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ExpenseItem expenseItem = await db.ExpenseItems.FindAsync(id);
            db.ExpenseItems.Remove(expenseItem);
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
