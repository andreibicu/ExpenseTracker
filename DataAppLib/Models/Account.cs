using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApp.Core.Models
{
    public class Account:BaseEntity
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Notes { get; set; }

        public virtual Voucher Voucher { get; set; }
        public virtual Check Check { get; set; }
        public virtual ExpenseItem ExpenseItem { get; set; }
    }
}
