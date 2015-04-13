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

            check = this.dbContext.Expenses.Include("Project").Include("CheckVoucher").SingleOrDefault(filter);

            return check;
        }

        public List<Expense> GetAll(Func<Expense, bool> filter = null)
        {
            List<Expense> expenses = new List<Expense>();

            if (filter != null)
            {
                expenses = this.dbContext.Expenses.Include("Project").Include("CheckVoucher").Where(filter).ToList();
                return expenses;
            }

            expenses = this.dbContext.Expenses.Include("Project").Include("CheckVoucher").ToList();
            return expenses;
        }

        public List<Expense> Find(string query)
        {
            var expenses = this.GetAll(e => e.Notes.ToLower().Contains(query) || e.ORNumber.ToLower().Contains(query) || e.Project.Name.ToLower().Contains(query));

            return expenses;
        }

        public void Delete(int id)
        {
            var entity = dbContext.Expenses.Find(id);
            dbContext.Expenses.Remove(entity);
            dbContext.SaveChanges();
        }
    }
}
