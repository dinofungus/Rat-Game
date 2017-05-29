using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RatGame
{

    class Program
    {
        public static string n;
        public static Random random = new Random();
        static void Main(string[] args)
        {
            Player player = null;
            Console.Write("Enter a name: ");
            n = Console.ReadLine();
            string path = "Saves/" + n + ".xml";
            if (File.Exists(path))
            {
                Console.WriteLine("Loading Player");
                System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(Player));
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                player = (Player)s.Deserialize(sr);
                sr.Close();
            }
            else
            {
                player = new Player(n);
            }
            Rat enemy1 = new Rat();
            Skeleton enemy2 = new Skeleton();                        
            Menu menu = new Menu(player);
            menu.LoadMenu();
            System.Threading.Thread.Sleep(1000);
            
        }
        public static bool Combat(Player p, Monster e)
        {
            while (e.health > 0 && p.health > 0)
            {
                Console.WriteLine("Press any key to attack");
                Console.ReadKey();
                Console.WriteLine();

                p.attack(e);
                if (e.health <= 0)
                {
                    Console.WriteLine("You defeat the " + e.name);
                    p.exp += e.expreward;
                    while (p.exp >= p.nextlevelexp)
                    {
                        p.LevelUp();
                    }
                    Console.ReadKey();
                    return false;
                }

                e.attack(p);
                if (p.health <= 0)
                {
                    Console.WriteLine("You die");
                    Console.ReadKey();
                    return true;
                }
                Console.WriteLine(p.name + " health: " + p.health);
                Console.WriteLine(e.name + " health: " + e.health);
                Console.WriteLine();
            }
            return true;
        }
        public static void Save(Player p)
        {
            string filename = "Saves/" + p.name + ".xml";
            var s = new System.Xml.Serialization.XmlSerializer(p.GetType());
            var sw = new StreamWriter(filename);
            s.Serialize(sw, p);
            sw.Close();
        }
    }
    
    
    
    
    
    
    
}
