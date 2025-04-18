using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Horizon.Tools;
using static Program;
using Horizon;
using System.Diagnostics;
using System.Linq.Expressions;
using System.ComponentModel.Design;
using System.Text.Json;

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
        public static void P(string line = "")
        {
            Console.WriteLine(line);
        }

        public static void PLS(string line = "", int delay = 0, int speed = 1)
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

        public static void PS(string line = "", int speed = 7)
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
                Console.Clear();
            }
            else if (Program.Mode == 1)
            {
                Console.Clear();
                Console.Clear();
                P("DEBUG MODE ENABLED");
                P("");
            }
            else if (Program.Mode == 2)
            {
                Console.Clear();
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
        public static void Newspaper()
        {
            P("_____________________________________________________________________________________________");
            P("|                                                            Sunday, August 30, 2011        |");
            P("|    _____ _            ______      _ _          _____                               _      |");
            P("|   |_   _| |           |  _  \\    (_) |        |_   _|                             | |     |");
            P("|     | | | |__   ___   | | | |__ _ _| |_   _     | |_ __ _   _ _ __ ___  _ __   ___| |_    |");
            P("|     | | | '_ \\ / _ \\  | | | / _` | | | | | |    | | '__| | | | '_ ` _ \\| '_ \\ / _ \\ __|   |");
            P("|     | | | | | |  __/  | |/ / (_| | | | |_| |    | | |  | |_| | | | | | | |_) |  __/ |_    |");
            P("|     \\_/ |_| |_|\\___|  |___/ \\__,_|_|_|\\__, |    \\_/_|   \\__,_|_| |_| |_| .__/ \\___|\\__|   |");
            P("|                                        __/ |                           | |                |");
            P("|                                       |___/                            |_|                |");
            P("|___________________________________________________________________________________________|");
            P("|                     |                                               |                     |");
            P("|     : :.:-..::.:..  |   Missing Scientist at local laboratory       |     :. ..-: =-:. +  |");
            P("|  :::: :.:-..::.:..  |   By Marissa Klein                            |  .:  . ..::.:..     |");
            P("|  ..-:. ..-: =-:. +  |                                               |  := .=:...=.-. . :  |");
            P("|  := .=:...=.-. . :  |   Officials at ####### ####, a private        |  ..::..   ::::- ::  |");
            P("|  ..::..   ::::- ::  |   research facility located in Rockwell,      |  :::: :.:-..::.:..  |");
            P("|  :::: :.:-..::.:..  |   Idaho, have confirmed that a staff member   |  .:  . ..::.:..     |");
            P("|  .:  . ..::.:..     |   is currently unaccounted for following      |  ..-:. ..-: =-:. +  |");
            P("|  ..-:. ..-: =-:. +  |   what they describe as an “internal          |  ::+: :.:-..::.:..  |");
            P("|  ::+: :.:-..::.:..  |   procedural anomaly” late Tuesday evening.   |                     |");
            P("|     :-_.: :+:  --:  |                                               |     .=:...=.-. . :  |");
            P("|  := .=:...=.-. . :  |   The individual, identified as Dr. Evan      |  :::: :.:-..::.:..  |");
            P("|  .:  . ..::.:..     |   Michaels, was last seen conducting          |  ..-:. ..-: =-:. +  |");
            P("|  ..-:. ..-: =-:. +  |   routine diagnostics in one of the lab’s     |  ::+: :.:-..::.:..  |");
            P("|  ::+: :.:-..::.:..  |   specialized research areas. According       |                     |");
            P("|                     |   to ####### representatives, standard        |     :-..::.:..=_:.  |");
            P("|     :-..::.:..=_:   |   safety protocols were in place at the       |  .:  . ..::.:..  +  |");
            P("|  .:  . ..::.:..     |   time, and there is currently no             |  =-: :.:-..:=:.:..  |");
            P("|  '. :-_.: :=:- --:  |   indication of foul play. However, this is   |  := .=:...=.-. . :  |");
            P("|_____________________|_______________________________________________|_____________________|");
            P("");
            PS("Press 'E' to exit");
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "e")
                {
                    break;
                }
            }
            C();
            if (SaveFile.PapersChecked == 0)
            {
                PS("- That's strange.", 30);
                S(1000);
                PS("- It's dated months after you were born.", 30);
                S(1000);
                PS("- What's a newspaper so old doing here?", 30);
                S(2000);
                SaveFile.PapersChecked += 1;
            }
            else if (SaveFile.PapersChecked == 1)
            {
                PS("- It's that same paper.", 30);
                S(1000);
                PS("- Why is it here?", 30);
                S(2000);
            }
        }
    }

}
