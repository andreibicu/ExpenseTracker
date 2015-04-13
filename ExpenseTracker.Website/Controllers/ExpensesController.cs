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
using DataApp.Core.Controllers;
using DataApp.Core;

namespace ExpenseTracker.Website.Controllers
{
    public class ExpensesController : Controller
    {
        private DataAppFacade db= null;
        private List<TransactionAccount> transactionAccounts = new List<TransactionAccount>();
        public ExpensesController()
        {
            this.db = new DataAppFacade();
            this.transactionAccounts = db.TransactionAccountController.GetAll();
        }
        // GET: Expenses
        public async Task<ActionResult> Index()
        {
            var expenses = db.ExpenseController.GetAll();//db.Expenses.Include(e => e.CheckVoucher).Include(e => e.Project);
            ViewBag.TransactionAccounts = db.TransactionAccountController.GetAll();
            return View(expenses);
        }

        // GET: Expenses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.ExpenseController.Get(e => e.Id == id);//await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            ViewBag.CheckVoucherID = new SelectList(db.CheckVoucherController.GetAll(), "Id", "CheckNo");
            ViewBag.ProjectId = new SelectList(db.ProjectController.GetAll(), "Id", "Name");
            ViewBag.CompanyId = new SelectList(this.transactionAccounts, "Id", "Name");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PurchaseDate,Notes,ORNumber,Amount,Category,ProjectId,CheckVoucherID,CompanyId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                //db.Expenses.Add(expense);
                //await db.SaveChangesAsync();
                this.db.ExpenseController.Add(expense);
                return RedirectToAction("Index");
            }

            ViewBag.CheckVoucherID = new SelectList(db.CheckVoucherController.GetAll(), "Id", "CheckNo", expense.CheckVoucherID);
            ViewBag.ProjectId = new SelectList(db.ProjectController.GetAll(), "Id", "Name", expense.ProjectId);
            ViewBag.CompanyId = new SelectList(this.transactionAccounts, "Id", "Name",expense.CompanyId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.ExpenseController.Get(e => e.Id == id); //await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.CheckVoucherID = new SelectList(db.CheckVoucherController.GetAll(), "Id", "CheckNo", expense.CheckVoucherID);
            ViewBag.ProjectId = new SelectList(db.ProjectController.GetAll(), "Id", "Name", expense.ProjectId);
            ViewBag.CompanyId = new SelectList(this.transactionAccounts, "Id", "Name", expense.CompanyId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PurchaseDate,Notes,ORNumber,Amount,Category,ProjectId,CheckVoucherID,CompanyId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(expense).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                db.ExpenseController.Update(expense);
                return RedirectToAction("Index");
            }
            ViewBag.CheckVoucherID = new SelectList(db.CheckVoucherController.GetAll(), "Id", "CheckNo", expense.CheckVoucherID);
            ViewBag.ProjectId = new SelectList(db.ProjectController.GetAll(), "Id", "Name", expense.ProjectId);
            ViewBag.CompanyId = new SelectList(this.transactionAccounts, "Id", "Name", expense.CompanyId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.ExpenseController.Get( e => e.Id == id); //await db.Expenses.FindAsync(id);
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
            //Expense expense = await db.Expenses.FindAsync(id);
            //db.Expenses.Remove(expense);
            //await db.SaveChangesAsync();
            db.ExpenseController.Delete(id);
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
