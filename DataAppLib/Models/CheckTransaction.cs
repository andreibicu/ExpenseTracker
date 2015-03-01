using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApp.Core.Models
{
    public class CheckTransaction:BaseEntity
    {
        public int CheckId { get; set; }
        public Decimal Amount { get; set; }

        public virtual Check Check { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
