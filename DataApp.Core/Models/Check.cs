using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DataApp.Core.Models
{

    
    public partial class Check
    {
        public Check()
        {
            this.CheckTransactions = new List<CheckTransaction>();
        }
    
        public int Id { get; set; }
        public decimal Amount { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime AddedOn { get; set; }
        public string Notes { get; set; }
        public int TransactionAccountId { get; set; }

        public  List<CheckTransaction> CheckTransactions { get; set; }
        //public virtual TransactionAccount TransactionAccount { get; set; }
        [NotMapped]
        public TransactionAccount TransactionAccount { get; set; }
    }
}
