using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
        public IEnumerable<TransactionAccount> Get()
        {
            //bool isSortDescending = false; //sort
            //string isSortBy = ""; //sortby
            //int page = 0; //page
            //int recordLimit = 0; //limit
            string query ="";//query
            List<TransactionAccount> accounts = new List<TransactionAccount>();

            //if (HttpContext.Current.Request["limit"] != null)
            //{
            //    int.TryParse((string)HttpContext.Current.Request["limit"], out recordLimit);
            //}

            //if (HttpContext.Current.Request["page"] != null)
            //{
            //    int.TryParse((string)HttpContext.Current.Request["page"], out page);
            //}

            if (HttpContext.Current.Request["query"] != null)
            {
                query = (string)HttpContext.Current.Request["query"];
                accounts = db.TransactionAccounts.Where(a => a.Name.Trim().ToLower().Contains(query.Trim().ToLower())).ToList();
            }
            else
            {
                accounts = db.TransactionAccounts.ToList();
            }

            //if (HttpContext.Current.Request["sort"] != null)
            //{

            //}

            //if (HttpContext.Current.Request["sort"] != null)
            //{

            //}

            return accounts;
        }

        // GET: api/TransactionAccounts/5
        //[ResponseType(typeof(TransactionAccount))]
        //public async Task<IHttpActionResult> Get(int id)
        //{
        //    TransactionAccount transactionAccount = await db.TransactionAccounts.FindAsync(id);
        //    if (transactionAccount == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(transactionAccount);
        //}

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