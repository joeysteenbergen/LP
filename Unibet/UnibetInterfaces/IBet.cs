using System;
using System.Collections.Generic;
using System.Text;

namespace UnibetInterfaces
{
    public interface IBet
    {
        string Home_Contestant { get; set; }
        string Game { get; set; }
        int Bet { get; set; }
        decimal Odd { get; set; }
        decimal Wage { get; set; }
    }
}
