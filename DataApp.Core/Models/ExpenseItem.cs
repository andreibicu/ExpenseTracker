using DataApp.Core.Enums;
namespace DataApp.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class ExpenseItem
    {
        public int Id { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public string Notes { get; set; }
        public string ORNumber { get; set; }
        public decimal Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public int ExpenseId { get; set; }
        public int TransactionAccountId { get; set; }
        public int ProjectId { get; set; }
    
        public  Expense Expense { get; set; }
        public Project Project { get; set; }
        //public virtual TransactionAccount TransactionAccount { get; set; }
        [NotMapped]
        public TransactionAccount TransactionAccount { get; set; }
    }
}
