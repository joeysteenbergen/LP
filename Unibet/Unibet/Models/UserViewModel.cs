using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unibet.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public decimal BankBalance { get; set; }
    }
}
