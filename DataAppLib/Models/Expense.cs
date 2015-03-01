using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApp.Core.Models
{
    public partial class Expense:BaseEntity
    {
        public Expense()
        {
            this.ExpenseItems = new HashSet<ExpenseItem>();
        }

        public virtual Voucher Voucher { get; set; }
        public virtual ICollection<ExpenseItem> ExpenseItems { get; set; }
    }
}
