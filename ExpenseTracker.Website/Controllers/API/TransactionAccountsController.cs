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

namespace ExpenseTracker.Website.Controllers.API
{
    public class TransactionAccountsController : ApiController
    {
        private DataAppContext db = new DataAppContext();

        // GET: api/TransactionAccounts
        public IQueryable<TransactionAccount> Get()
        {
            //bool isSearching = false;

            

            return db.TransactionAccounts;
        }

        // GET: api/TransactionAccounts/5
        [ResponseType(typeof(TransactionAccount))]
        public async Task<IHttpActionResult> Get(int id)
        {
            TransactionAccount transactionAccount = await db.TransactionAccounts.FindAsync(id);
            if (transactionAccount == null)
            {
                return NotFound();
            }

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