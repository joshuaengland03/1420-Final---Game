using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Horizon.Tools;
using Horizon;
using System.Diagnostics;

public class World
{
    public static int ChoiceNumber { get; set; }
    public static int Choose()
    {
        string input = Console.ReadLine().ToLower();

        switch (input)
        {
            case "1":
                return 1;
                break;
            case "2":
                return 2;
                break;
            case "3":
                return 3;
                break;
            case "4":
                return 4;
                break;
            case "I":
                return 10;
                break;
            case "S":
                return 11;
            case "Q":
                return 12;
                break;
            default:
                P("Invalid input, try again.");
                Choose();
                return 0;
                break;
        }
    }

    public static int CleanChoice()
    {
        int choice = 0;
        return choice;
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
        PS("You get out of bed and get dressed");
        Thread.Sleep(1000);
    }
    public static void Run()
    {
        Console.WriteLine("You are in the Bedroom");
        while (true)
        {
            PS($"What would you like to do?");
            PS($"1. Open the drawer");
            PS($"2. Look in the mirror");
            PS($"3. Look under your bed");
            PS($"4. Leave the room");
            P("");
            P("");
            PS($"I. Check Inventory");
            PS($"S. Save");
            PS($"Q. Quit");
            Choose();
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
