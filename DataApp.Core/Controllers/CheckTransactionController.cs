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
    public class CheckTransactionController : Controller<CheckTransaction>, IAddData<CheckTransaction>//, IReadData<CheckTransaction>, IModifyData<CheckTransaction>
    {
        public CheckTransactionController(DataAppContext dbContext)
            :base(dbContext)
        {
        }

        public bool Add(CheckTransaction entity)
        {
            return this.repo.Add(entity);
        }

        public bool Update(CheckTransaction entity)
        {
            return this.repo.Update(entity);
        }

        public CheckTransaction Get(Func<CheckTransaction, bool> filter)
        {
            CheckTransaction check = null;

            check = this.dbContext.CheckTransactions.Include("Voucher").Include("Check").SingleOrDefault(filter);

            return check;
        }

        public List<CheckTransaction> GetAll(Func<CheckTransaction, bool> filter = null)
        {
            if (filter == null)
                return this.dbContext.CheckTransactions.Include("Voucher").Include("Check").ToList();

            return this.dbContext.CheckTransactions.Include("Voucher").Include("Check").Where(filter).ToList();
        }
    }
}

