using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApp.Core.Models
{
    public class User:BaseEntity
    {
        public String Username { get; set; }
        public String Password { get; set; }
    }
}
