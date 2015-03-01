using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataApp.Core.Enums;

namespace DataApp.Core.Models
{
    public partial class ExpenseItem:BaseEntity
    {
        public int ExpenseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Description { get; set; }
        public string ORNumber { get; set; }
        public int ProjectId { get; set; }
        public Decimal Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public VoucherType Type { get; set; }

        public virtual Expense Expense { get; set; }
        public virtual Account CompanyAccount { get; set; }
        public virtual Project Project { get; set; }
    }
}
