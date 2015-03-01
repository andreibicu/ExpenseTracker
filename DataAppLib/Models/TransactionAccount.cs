using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApp.Core.Models
{
    public class TransactionAccount:BaseEntity
    {
        public String Name { get; set; }
        public String Contact { get; set; }
        public String TIN { get; set; }
        public String Notes { get; set; }
    }
}
