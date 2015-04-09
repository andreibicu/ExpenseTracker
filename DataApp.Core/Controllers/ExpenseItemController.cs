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
    public class ExpenseItemController : Controller<ExpenseItem>, IAddData<ExpenseItem>, IModifyData<ExpenseItem>//, IReadData<ExpenseItem>
    {
        public ExpenseItemController(DataAppContext dbContext)
            :base(dbContext)
        {
        }

        public bool Add(ExpenseItem entity)
        {
            return this.repo.Add(entity);
        }

        public bool Update(ExpenseItem entity)
        {
            return this.repo.Update(entity);
        }

        public ExpenseItem Get(Func<ExpenseItem, bool> filter)
        {
            ExpenseItem expenseItem = null;

            expenseItem = this.dbContext.ExpenseItems.Include("Expense").Include("Project").SingleOrDefault(filter);

            return expenseItem;
        }

        public List<ExpenseItem> GetAll(Func<ExpenseItem, bool> filter = null)
        {
            if (filter == null)
                return this.dbContext.ExpenseItems.Include("Expense").Include("Project").ToList();

            return this.dbContext.ExpenseItems.Include("Expense").Include("Project").Where(filter).ToList();
        }
    }
}

