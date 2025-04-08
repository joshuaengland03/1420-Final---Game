using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Horizon.Tools;
using Horizon;
using System.Diagnostics;
using System.Linq.Expressions;

public class World
{
    public static int ChoiceNumber { get; set; }
    public static Dictionary<int, string> Choices { get; set; } = new Dictionary<int, string>();
    public static Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>
    {
        { "I", "Check Inventory" },
        { "S", "Save Game" },
        { "Q", "Quit" }
    };

    public static int Choose()
    {
        PS("You are in the Bedroom");
        P("");
        foreach (var choice in Choices)
        {
            if (choice.Key > ChoiceNumber)
            {
                break;
            }
            else
            {
                PS($"{choice.Key}: {choice.Value}");
            }
        }
        P("");
        foreach (var option in Options)
        {
            PS($"{option.Key}: {option.Value}");
        }
        P("");
        while (true)
        {
            string input = Console.ReadLine().ToLower();
            if (int.TryParse(input, out int number))
            {
                if (number <= ChoiceNumber && number > 0)
                {
                    return number;
                }
                else
                {
                    P("Number invalid. Try again.");
                }
            }
            else
            {
                if (input == "i")
                {
                    return 11;
                }
                else if (input == "s")
                {
                    return 12;
                }
                else if (input == "q")
                {
                    return 13;
                }
                else
                {
                    P("Option invalid. Try again.");
                }
            }
        }
    }
}

public class Bedroom : World
{
    public static void Start()
    {
        DS(Program.Mom, 1, 40);
        Thread.Sleep(1000);
        DS(Program.Mom, 2, 40);
        Thread.Sleep(1000);
        DS(Program.Mom, 3, 40);
        Thread.Sleep(1000);
        Console.Clear();
        PS("You get out of bed and get dressed.");
        Thread.Sleep(1000);
    }
    public static void Run()
    {
        ChoiceNumber = 4;
        Choices.Clear();

        Choices.Add(1, "Open the drawer");
        Choices.Add(2, "Look in the mirror");
        Choices.Add(3, "Look under your bed");
        Choices.Add(4, "Leave the room");
        Choices.Add(5, "BUG, SHOULD NOT APPEAR");

        int choice = Choose();
        P($"{choice}");
        switch (choice)
        {
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 11:

                break;
            case 12:

                break;
            case 13:

                break;
            default:
                break;
        }

    }
}

public class LivingRoom : World
{
    public static void Run()
    {
        Console.WriteLine("You are in the Living Room");
    }
}

public class Kitchen : World
{
    public static void Run()
    {
        Console.WriteLine("You are in the Kitchen");
    }
}

public class Street : World
{
    public static void Run()
    {
        Console.WriteLine("You are in the Street");
    }
}

public class BusStop1 : World
{
    public static void Run()
    {
        Console.WriteLine("You are at Bus Stop G24");
    }
}

public class BusStop2 : World
{
    public static void Run()
    {
        Console.WriteLine("You are at Bus Stop L12");
    }
}

public class BusStop3 : World
{
    public static void Run()
    {
        Console.WriteLine("You are at Bus Stop B72");
    }
}

public class School : World
{
    public static void Run()
    {
        Console.WriteLine("You are at School");
    }
}

public class Hallway : World
{
    public static void Run()
    {
        Console.WriteLine("You are in the Hallway");
    }
}

public class Arcade : World
{
    public static void Run()
    {
        Console.WriteLine("You are at the Arcade");
    }
}

public class Playground : World
{
    public static void Run()
    {
        Console.WriteLine("You are at the School Playground");
    }
}

public class Unknown : World
{
    public static void Run()
    {
        Console.WriteLine("You shouldn't be here.");
    }
}
