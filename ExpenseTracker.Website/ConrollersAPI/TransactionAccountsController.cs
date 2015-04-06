using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DataApp.Core.DAL;
using DataApp.Core.Models;

namespace ExpenseTracker.Website.ConrollersAPI
{
    public class TransactionAccountsController : ApiController
    {
        private DataAppContext db = new DataAppContext();

        // GET: api/TransactionAccounts
        public IQueryable<TransactionAccount> GetTransactionAccounts()
        {
            return db.TransactionAccounts;
        }

        // GET: api/TransactionAccounts/5
        [ResponseType(typeof(TransactionAccount))]
        public async Task<IHttpActionResult> GetTransactionAccount(int id)
        {
            TransactionAccount transactionAccount = await db.TransactionAccounts.FindAsync(id);
            if (transactionAccount == null)
            {
                return NotFound();
            }

            return Ok(transactionAccount);
        }

        // PUT: api/TransactionAccounts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTransactionAccount(int id, TransactionAccount transactionAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transactionAccount.Id)
            {
                return BadRequest();
            }

            db.Entry(transactionAccount).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TransactionAccounts
        [ResponseType(typeof(TransactionAccount))]
        public async Task<IHttpActionResult> PostTransactionAccount(TransactionAccount transactionAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TransactionAccounts.Add(transactionAccount);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = transactionAccount.Id }, transactionAccount);
        }

        // DELETE: api/TransactionAccounts/5
        [ResponseType(typeof(TransactionAccount))]
        public async Task<IHttpActionResult> DeleteTransactionAccount(int id)
        {
            TransactionAccount transactionAccount = await db.TransactionAccounts.FindAsync(id);
            if (transactionAccount == null)
            {
                return NotFound();
            }

            db.TransactionAccounts.Remove(transactionAccount);
            await db.SaveChangesAsync();

            return Ok(transactionAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransactionAccountExists(int id)
        {
            return db.TransactionAccounts.Count(e => e.Id == id) > 0;
        }
    }
}