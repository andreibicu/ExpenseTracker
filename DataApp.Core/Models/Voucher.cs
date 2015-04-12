using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataApp.Core.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Voucher
    {
        public Voucher()
        {
            //this.CheckTransactions = new List<CheckTransaction>();
            this.Expenses = new List<Expense>();
        }
    
        public int Id { get; set; }
        public bool IsExpense { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime AddedOn { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime IssuedOn { get; set; }
        public string Notes { get; set; }
        public int TransactionAccountId { get; set; }

        //public  List<CheckTransaction> CheckTransactions { get; set; }
        public  List<Expense> Expenses { get; set; }
        //public virtual TransactionAccount TransactionAccount { get; set; }
        [NotMapped]
        public TransactionAccount TransactionAccount { get; set; }
    }
}
