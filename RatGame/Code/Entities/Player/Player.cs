using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acoolconsoleapplication
{
    public class Player : Entity
    {
        public int exp;
        public int nextlevelexp;
        
        public Player()
        {
            Console.WriteLine("Player loaded");
        }
        public Player(string n)
        {

            name = n;
            Console.Write("Generating Player");
            System.Threading.Thread.Sleep(1000);
            maxhealth = Program.random.Next(15, 26);
            health = maxhealth;
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
            attacklo = Program.random.Next(3, 8);
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
            attackhi = attacklo + Program.random.Next(1, 4);
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
            accuracy = Program.random.Next(45, 71);
            level = 1;
            exp = 0;
            nextlevelexp = 5 * level * level;
            Console.WriteLine(".");

            Stats();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine();
        }
        public void Stats()
        {
            Console.WriteLine("Your stats are:");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Attack: " + attacklo + "-" + attackhi);
            Console.WriteLine("Accuracy: " + accuracy);
            Console.WriteLine();
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Exp: " + exp + "/" + nextlevelexp);
        }
        public void LevelUp()
        {
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
