using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acoolconsoleapplication
{
    class Menu
    {
        Player player;
        public Menu(Player p)
        {
            player = p;
        }
        public void LoadMenu()
        {
            string input;
            string command;
            string subcommand;
            string[] seperators = { " ", ",", ".", ";" };
            string[] splitcommand;
            List<string> commands = new List<string>();
            commands.Add("attack");
            commands.Add("exit");
            commands.Add("help");
            commands.Add("save");
            commands.Add("stats");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter a command");
                Console.WriteLine("Enter 'help' for a list of commands");
                Console.WriteLine();
                input = Console.ReadLine();
                splitcommand = input.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                command = splitcommand[0];
                if (splitcommand.Length > 1)
                {
                    subcommand = splitcommand[1];
                }
                switch (command)
                {
                    case "attack":
                        exit = Attack();
                        Console.WriteLine();
                        break;
                    case "help":
                        Console.WriteLine("Possible Commands:");
                        foreach (string i in commands)
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine();
                        break;
                    case "exit":
                        exit = true;
                        Console.WriteLine();
                        break;
                    case "save":
                        Console.WriteLine("Saving...");
                        Program.Save(player);
                        Console.WriteLine("Saved Player " + player.name);
                        Console.WriteLine();
                        break;
                    case "stats":
                        player.Stats();
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Not a valid command");
                        Console.WriteLine();
                        break;
                }
            }

        }
        private bool Attack()
        {
            Rat enemy1 = new Rat();
            Skeleton enemy2 = new Skeleton();
            Brother enemy3 = new Brother();
            int succession = Program.random.Next(1, 1000000);
            if (succession == 1000000)
            {
                Console.Write("Your brother has claimed the throne!");
                return Program.Combat(player, enemy3);
            }
            else
            {
                return Program.Combat(player, enemy2);
            }
        }
        private void Help()
        {

        }
    }
}
