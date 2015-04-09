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
    public class ChecksController : Controller
    {
        private DataAppContext db = new DataAppContext();

        // GET: Checks
        public async Task<ActionResult> Index()
        {
            List<TransactionAccount> accounts = db.TransactionAccounts.ToList();
            ViewBag.TransactionAccounts = accounts;
            if (Request["search"] != null)
            {
                string query = (string)Request["search"].ToLower();
                var result = await db.Checks.Where(p => p.Notes.ToLower().Contains(query)).ToListAsync();
                return View();
            }

            return View(await db.Checks.ToListAsync());
        }

        // GET: Checks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check check = await db.Checks.FindAsync(id);
            if (check == null)
            {
                return HttpNotFound();
            }
            return View(check);
        }

        // GET: Checks/Create
        public ActionResult Create()
        {
            ViewBag.TransactionAccountId = new SelectList(db.TransactionAccounts, "Id", "Name");
            return View();
        }

        // POST: Checks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Amount,Notes,TransactionAccountId")] Check check)
        {
            if (ModelState.IsValid)
            {
                check.AddedOn = DateTime.Now.Date;
                db.Checks.Add(check);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TransactionAccountId = new SelectList(db.TransactionAccounts, "Id", "Name",check.TransactionAccountId);
            return View(check);
        }

        // GET: Checks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check check = await db.Checks.FindAsync(id);
            if (check == null)
            {
                return HttpNotFound();
            }

            ViewBag.TransactionAccountId = new SelectList(db.TransactionAccounts, "Id", "Name",check.TransactionAccountId);
            return View(check);
        }

        // POST: Checks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Amount,AddedOn,Notes,TransactionAccountId")] Check check)
        {
            if (ModelState.IsValid)
            {
                db.Entry(check).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TransactionAccountId = new SelectList(db.TransactionAccounts, "Id", "Name", check.TransactionAccountId);
            return View(check);
        }

        // GET: Checks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check check = await db.Checks.FindAsync(id);
            if (check == null)
            {
                return HttpNotFound();
            }
            return View(check);
        }

        // POST: Checks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Check check = await db.Checks.FindAsync(id);
            db.Checks.Remove(check);
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
