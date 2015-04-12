namespace DataApp.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using DataApp.Core.Enums;
    
    public partial class Expense
    {

        public int Id { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime PurchaseDate { get; set; }
        public string Notes { get; set; }
        public string ORNumber { get; set; }
        public decimal Amount { get; set; }
        public ExpenseCategory Category { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public int CheckVoucherID { get; set; }
        public virtual CheckVoucher CheckVoucher { get; set; }

        public int CompanyId { get; set; }
        [NotMapped]
        public TransactionAccount Company { get; set; }
    }
}
