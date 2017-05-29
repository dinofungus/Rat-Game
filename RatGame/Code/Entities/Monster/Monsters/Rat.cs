using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatGame
{
    class Rat : Monster
    {
        public Rat()
        {
            health = 10;
            attackhi = 3;
            attacklo = 1;
            accuracy = 25;
            expreward = 10;
            name = "rat";
        }
    }
}
