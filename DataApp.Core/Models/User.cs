using System;

namespace DataApp.Core.Models
{
    public class User:BaseEntity
    {
        public String Username { get; set; }
        public String Password { get; set; }
    }
}
