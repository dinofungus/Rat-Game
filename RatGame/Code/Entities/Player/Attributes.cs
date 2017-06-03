﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatGame
{
    public class Attributes
    {
        string[] attributeNames = new string[5] { "Strength", "Vitality", "Dexterity", "Wisdom", "Luck" };

        public int[] baseAttributes = new int[5] { 5, 5, 5, 5, 5 };

        public int[] pointAttributes = new int[5] { 0, 0, 0, 0, 0 };

        public int[] finalAttributes = new int[5];

        public Attributes()
        {
            Console.WriteLine("Attributes Loaded");
        }
        public Attributes(bool r)
        {
            bool reroll = r;

            while (reroll)
            {
                for (int i = 0; i < baseAttributes.Length; i++)
                {
                    baseAttributes[i] = 5;
                }
                for (int i = 0; i < 10; i++)
                {
                    baseAttributes[Program.random.Next(0, 5)]++;
                }
                Console.WriteLine("Your attributes are:");
                for (int i = 0; i < baseAttributes.Length; i++)
                {
                    finalAttributes[i] = baseAttributes[i];
                    Console.WriteLine(attributeNames[i] + ": " + finalAttributes[i]);
                }
                
                bool valid = false;
                do
                {
                    Console.WriteLine("Reroll? Y/N");
                    string rerollInput = Console.ReadLine();
                    switch (rerollInput)
                    {
                        case "Y":
                        case "y":
                            Console.WriteLine("Rerolling...");
                            reroll = true;
                            valid = true;
                            break;
                        case "N":
                        case "n":
                            Console.WriteLine("Attributes confirmed");
                            reroll = false;
                            valid = true;
                            break;
                        default:
                            Console.WriteLine("Not a valid answer");
                            valid = false;
                            break;
                    }
                } while (!valid);
                

            }

        }
        public void Display()
        {
            for (int i = 0; i < finalAttributes.Length; i++)
            {
                Console.WriteLine(attributeNames[i] + ": " + finalAttributes[i]);
            }
        }
    }
}
