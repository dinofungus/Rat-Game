using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatGame
{
    class Skeleton : Monster
    {
        public Skeleton()
        {
            health = 18;
            attackhi = 5;
            attacklo = 3;
            accuracy = 40;
            expreward = 25;
            name = "skeleton";
        }
    }
}
