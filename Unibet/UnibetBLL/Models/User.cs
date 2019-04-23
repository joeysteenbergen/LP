using System;
using System.Collections.Generic;
using System.Text;
using UnibetInterfaces;

namespace UnibetBLL.Models
{
    internal class User : IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public decimal BankBalance { get; set; }
    }
}
