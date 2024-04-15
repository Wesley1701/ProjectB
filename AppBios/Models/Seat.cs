using System;
using System.Collections.Generic;
using System.Text;

namespace AppBios.Models
{
    internal class Seat
    {
        public bool IsTaken;
        public double Cost;

        public Seat(double cost)
        {
            IsTaken = false;
            Cost = cost;
        }
    }
}
