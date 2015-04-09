using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataApp.Core.Abstracts;
using DataApp.Core.DAL;
using DataApp.Core.Models;
namespace DataApp.Core.Controllers
{
    public class CheckController : Controller<Check>, IAddData<Check>, IModifyData<Check>//, IReadData<Check>
    {
        public CheckController(DataAppContext dbContext)
            :base(dbContext)
        {
        }

        public bool Add(Check entity)
        {
            return this.repo.Add(entity);
        }

        public bool Update(Check entity)
        {
            return this.repo.Update(entity);
        }

        public Check Get(Func<Check, bool> filter)
        {
            Check check = null;

            check = this.dbContext.Checks.Include("CheckTransactions").SingleOrDefault(filter);
            check.TransactionAccount = this.dbContext.TransactionAccounts.SingleOrDefault(
                ta => ta.Id == check.TransactionAccountId
            );

            return check;
        }

        public List<Check> GetAll(Func<Check, bool> filter = null)
        {
            if (filter == null)
                return this.dbContext.Checks.Include("CheckTransactions").ToList();

            return this.dbContext.Checks.Include("CheckTransactions").Where(filter).ToList();
        }
    }
}
