using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatGame
{
    public class Player : Entity
    {
        public int exp;
        public int nextlevelexp;
        public Attributes attributes;
        
        public Player()
        {
            //Constructor for loading player
            Console.WriteLine("Player loaded");
        }
        public Player(string n)
        {
            //Constructor for creating player
            name = n;

            attributes = new Attributes(true);

            health = attributes.finalAttributes[1] * 3;
            attacklo = attributes.finalAttributes[0];
            attackhi = attributes.finalAttributes[0] + 2;
            accuracy = attributes.finalAttributes[2] * 10;
            if (accuracy > 80)
            {
                //remove this once better accuracy implemented
                accuracy = 80;
            }

            Stats();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }
        public void Stats()
        {
            //Print player stats
            Console.WriteLine("Your stats are:");
            Console.WriteLine("Name: " + name);
            attributes.Display();
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Attack: " + attacklo + "-" + attackhi);
            Console.WriteLine("Accuracy: " + accuracy);
            Console.WriteLine();
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Exp: " + exp + "/" + nextlevelexp);
        }
        public void LevelUp()
        {
            //Level up and increase stats
            level++;
            exp -= nextlevelexp;
            nextlevelexp = 5 * level * level;
            maxhealth += Program.random.Next(2, 6);
            health = maxhealth;
            int atkup = Program.random.Next(1, 4);
            attacklo += atkup;
            attackhi += atkup;
            if (accuracy < 80)
            {
                accuracy += Program.random.Next(2, 5);
            }
            if (accuracy > 80)
            {
                accuracy = 80;
            }
            Console.WriteLine();
            Console.WriteLine("You reached level " + level);
            Console.WriteLine("Your stats are:");
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Attack: " + attacklo + "-" + attackhi);
            Console.WriteLine("Accuracy: " + accuracy);
            Console.WriteLine("Press any key to continue");
            Console.WriteLine();
        }
    }
}
