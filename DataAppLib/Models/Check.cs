using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApp.Core.Models
{
    public class Check:BaseEntity
    {
        public Check()
        {
            this.CheckTransactions = new HashSet<CheckTransaction>();
        }

        public DateTime IssueDate { get; set; }
        public Decimal Amount { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<CheckTransaction> CheckTransactions { get; set; }
        public virtual Account PayeeAccount { get; set; }
    }
}
