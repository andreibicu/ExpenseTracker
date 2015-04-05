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
    public class VoucherController : Controller<Voucher>, IAddData<Voucher>, IReadData<Voucher>, IModifyData<Voucher>
    {
        public VoucherController(DataAppContext dbContext)
            :base(dbContext)
        {
        }

        public bool Add(Voucher entity)
        {
            return this.repo.Add(entity);
        }

        public bool Update(Voucher entity)
        {
            return this.repo.Update(entity);
        }

        public Voucher Get(Func<Voucher, bool> filter)
        {
            Voucher check = null;

            check = this.dbContext.Vouchers.Include("CheckTransactions").Include("Expenses").SingleOrDefault(filter);
            check.TransactionAccount = this.dbContext.TransactionAccounts.SingleOrDefault(
                ta => ta.Id == check.TransactionAccountId
            );

            return check;
        }

        public List<Voucher> GetAll(Func<Voucher, bool> filter = null)
        {
            if (filter == null)
                return this.dbContext.Vouchers.Include("CheckTransactions").Include("Expenses").ToList();

            return this.dbContext.Vouchers.Include("CheckTransactions").Include("Expenses").Where(filter).ToList();
        }
    }
}
