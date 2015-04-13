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

    public class CheckVoucherController : Controller<CheckVoucher>, IAddData<CheckVoucher>, IModifyData<CheckVoucher>//, IReadData<Expense>
    {
        public CheckVoucherController(DataAppContext dbContext)
            : base(dbContext)
        {

        }

        public bool Add(CheckVoucher entity)
        {
            return this.repo.Add(entity);
        }

        public bool Update(CheckVoucher entity)
        {
            return this.repo.Update(entity);
        }

        public CheckVoucher Get(Func<CheckVoucher, bool> filter)
        {
            CheckVoucher check = null;

            check = this.dbContext.CheckVouchers.Include("Expenses").SingleOrDefault(filter);

            return check;
        }

        public List<CheckVoucher> GetAll(Func<CheckVoucher, bool> filter = null)
        {
            List<CheckVoucher> checkVouchers = new List<CheckVoucher>();

            if (filter != null)
            {
                checkVouchers = this.dbContext.CheckVouchers.Include("Expenses").Where(filter).ToList();
                return checkVouchers;
            }

            checkVouchers = this.dbContext.CheckVouchers.Include("Expenses").ToList();
            return checkVouchers;
        }

        public List<CheckVoucher> Find(string query)
        {
            List<CheckVoucher> checkVouchers = new List<CheckVoucher>();

            checkVouchers = this.dbContext.CheckVouchers.Include("Expenses").Where(c => c.Notes.ToLower().Contains(query) || c.CheckNo.ToLower().Contains(query) || c.VoucherNo.ToLower().Contains(query)).ToList();
            return checkVouchers;
        }


        public void Delete(int id)
        {
            var entity = dbContext.CheckVouchers.Find(id);
            dbContext.CheckVouchers.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
