using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataApp.Core.Enums;

namespace DataApp.Core.Models
{
    public class Voucher:BaseEntity
    {
        public DateTime IssueDate { get; set; }
        public DateTime EntryDate { get; set; }

        public virtual CheckTransaction CheckTransaction { get; set; }
        public virtual Account PayeeAccount { get; set; }
        public virtual Expense Expense { get; set; }
    }
}
