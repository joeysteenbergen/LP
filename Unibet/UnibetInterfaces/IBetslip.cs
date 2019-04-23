using System;
using System.Collections.Generic;
using System.Text;

namespace UnibetInterfaces
{
    public interface IBetslip
    {
        List<IBet> Bets { get; set; }
        int UserID { get; set; }
    }
}
