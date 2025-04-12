using Horizon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon
{

    public enum Room
    {
        Bedroom = 0,
        LivingRoom = 1,
        Kitchen = 2,
        Street = 3,
        BusStop1 = 4,
        BusStop2 = 5,
        BusStop3 = 6,
        School = 7,
        Hallway = 8,
        Arcade = 9,
        Playground = 10,
        Unknown = 11,
    }

    public static class Tools
    {
        public static void P(string line)
        {
            Console.WriteLine(line);
        }

        public static void PLS(string line, int delay = 0, int speed = 1)
        {
            if (Program.Mode != 1)
            {
                foreach (char c in line)
                {
                    Console.Write(c);
                    Thread.Sleep(speed);
                }
                Thread.Sleep(delay);
            }
            else
            {
                Console.Write(line);
            }
        }

        public static void D(Character character, int key)
        {
            P($"{character.Name}: {character.CDialogue[key]}");
        }

        public static void DS(Character character, int key, int speed = 1)
        {
            PS($"{character.Name}: {character.CDialogue[key]}", speed);
        }

        public static void NDS(Character character, int key, int speed = 1)
        {
            PS($"{character.CDialogue[key]}", speed);
        }

        public static void PS(string line, int speed = 1)
        {
            if (Program.Mode != 1)
            {
                foreach (char c in line)
                {
                    Console.Write(c);
                    Thread.Sleep(speed);
                }
                Console.Write("\n");
            }
            else
            {
                P(line);
            }
        }

        public static void C()
        {
            if (Program.Mode == 0)
            {
                Console.Clear();
            }
            else if (Program.Mode == 1)
            {
                Console.Clear();
                P("DEBUG MODE ENABLED");
                P("");
            }
            else if (Program.Mode == 2)
            {
                Console.Clear();
                P("TEST MODE ENABLED");
                P("");
            }
        }

        public static void S(int delay)
        {
            if (Program.Mode == 1)
            {
                Thread.Sleep(0);
            }
            else
            {
                Thread.Sleep(delay);
            }
        }
    }
}
