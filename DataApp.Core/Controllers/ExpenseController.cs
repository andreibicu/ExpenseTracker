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
    public class ExpenseController : Controller<Expense>, IAddData<Expense>, IModifyData<Expense>//, IReadData<Expense>
    {
        public ExpenseController(DataAppContext dbContext)
            :base(dbContext)
        {
        }

        public bool Add(Expense entity)
        {
            return this.repo.Add(entity);
        }

        public bool Update(Expense entity)
        {
            return this.repo.Update(entity);
        }

        public Expense Get(Func<Expense, bool> filter)
        {
            Expense check = null;

            check = this.dbContext.Expenses.Include("ExpenseItems").SingleOrDefault(filter);

            return check;
        }

        public List<Expense> GetAll(Func<Expense, bool> filter = null)
        {
            if (filter == null)
                return this.dbContext.Expenses.Include("ExpenseItems").ToList();

            return this.dbContext.Expenses.Include("ExpenseItems").Where(filter).ToList();
        }
    }
}
