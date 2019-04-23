﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnibetInterfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        decimal BankBalance { get; set; }
    }
}
