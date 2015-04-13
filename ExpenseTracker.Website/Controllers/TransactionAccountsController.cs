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
    [Authorize]
    public class TransactionAccountsController : Controller
    {
        private DataAppFacade db = new DataAppFacade();

        // GET: TransactionAccounts
        public async Task<ActionResult> Index()
        {
            //return View(await db.TransactionAccounts.ToListAsync());
            return View(db.TransactionAccountController.GetAll());
        }

        // GET: TransactionAccounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionAccount transactionAccount = db.TransactionAccountController.Get(id); //await db.TransactionAccounts.FindAsync(id);
            if (transactionAccount == null)
            {
                return HttpNotFound();
            }
            return View(transactionAccount);
        }

        // GET: TransactionAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Notes")] TransactionAccount transactionAccount)
        {
            if (ModelState.IsValid)
            {
                //db.TransactionAccounts.Add(transactionAccount);
                //await db.SaveChangesAsync();
                db.TransactionAccountController.Add(transactionAccount);
                return RedirectToAction("Index");
            }

            return View(transactionAccount);
        }

        // GET: TransactionAccounts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionAccount transactionAccount = db.TransactionAccountController.Get(id); //await db.TransactionAccounts.FindAsync(id);
            if (transactionAccount == null)
            {
                return HttpNotFound();
            }
            return View(transactionAccount);
        }

        // POST: TransactionAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Notes")] TransactionAccount transactionAccount)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(transactionAccount).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                this.db.TransactionAccountController.Update(transactionAccount);
                return RedirectToAction("Index");
            }
            return View(transactionAccount);
        }

        // GET: TransactionAccounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionAccount transactionAccount = this.db.TransactionAccountController.Get(id); //await db.TransactionAccounts.FindAsync(id);
            if (transactionAccount == null)
            {
                return HttpNotFound();
            }
            return View(transactionAccount);
        }

        // POST: TransactionAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //TransactionAccount transactionAccount = await db.TransactionAccounts.FindAsync(id);
            //db.TransactionAccounts.Remove(transactionAccount);
            //await db.SaveChangesAsync();
            this.db.TransactionAccountController.Delete(id);
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
