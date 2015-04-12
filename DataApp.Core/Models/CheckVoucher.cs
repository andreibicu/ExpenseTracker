using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApp.Core.Models
{
    public class CheckVoucher
    {
        public CheckVoucher()
        {
            this.Expenses = new List<Expense>();                
        }

        public int Id { get; set; }
        public Decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
        public string CheckNo { get; set; }
        public string VoucherNo { get; set; }
        public string Notes { get; set; }
        
        public int PayeeId { get; set; }

        [NotMapped]
        public TransactionAccount Payee { get; set; }

        public virtual List<Expense> Expenses { get; set; }
    }
}
