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
    #region Choose
    public static int Choose()
    {
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
    #endregion
}
#region Bedroom
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
        PS("- You get out of bed and get dressed.", 30);
        Thread.Sleep(3000);
        Console.Clear();
    }
    public static void Run()
    {
        ChoiceNumber = 5;
        Choices.Clear();

        Choices.Add(1, "Open the drawer");
        Choices.Add(2, "Look in the mirror");
        Choices.Add(3, "Look under your bed");
        Choices.Add(4, "Check the clock");
        Choices.Add(5, "Leave the room");
        Choices.Add(6, "BUG, SHOULD NOT APPEAR");
        PS("- You are in the Bedroom", 30);
        P("");
        int choice = Choose();
        Console.Clear();
        switch (choice)
        {
            case 1:
                PLS("- You try to open the drawer, ", 600, 30);
                PS("but it's locked.", 30);
                Thread.Sleep(2000);
                break;
            case 2:
                PLS("- You look in the mirror. ", 600, 30);
                PS("It's You!", 30);
                Thread.Sleep(2000);
                break;
            case 3:
                // FIX, ENDS IN EXCEPTION ERROR
                foreach (var item in Save.Inventory)
                {
                    if (item.Key == 1)
                    {
                        PLS("- You look under the bed again, ", 600, 30);
                        PS("but there was nothing", 30);
                        break;
                    }
                    else
                    {
                        PS("- You look under the bed, and you find a small key.", 30);
                        Thread.Sleep(500);
                        Save.Inventory.Add(1, "Small Key");
                        PS("(KEY added to inventory)");
                        Thread.Sleep(2000);
                    }
                }
                break;
            case 4:
                PLS("You check the clock, ", 600, 30);
                PS("it's 00:00", 30);
                Thread.Sleep(2000);
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
        Console.Clear();
    }
}
#endregion 
#region LivingRoom
public class LivingRoom : World
{
    public static void Run()
    {
        ChoiceNumber = 0;
        Choices.Clear();

        Choices.Add(1, "PLACEHOLDER");
        Choices.Add(2, "PLACEHOLDER");
        Choices.Add(3, "PLACEHOLDER");
        Choices.Add(4, "PLACEHOLDER");
        Choices.Add(5, "PLACEHOLDER");
        Choices.Add(6, "PLACEHOLDER");
        PS("- ", 30);
        P("");
        int choice = Choose();
        Console.Clear();
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
        Console.Clear();
    }
}
#endregion
#region Kitchen
public class Kitchen : World
{
    public static void Run()
    {
        ChoiceNumber = 0;
        Choices.Clear();

        Choices.Add(1, "PLACEHOLDER");
        Choices.Add(2, "PLACEHOLDER");
        Choices.Add(3, "PLACEHOLDER");
        Choices.Add(4, "PLACEHOLDER");
        Choices.Add(5, "PLACEHOLDER");
        Choices.Add(6, "PLACEHOLDER");
        PS("- ", 30);
        P("");
        int choice = Choose();
        Console.Clear();
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
        Console.Clear();
    }
}
#endregion
#region Street
public class Street : World
{
    public static void Run()
    {
        ChoiceNumber = 0;
        Choices.Clear();

        Choices.Add(1, "PLACEHOLDER");
        Choices.Add(2, "PLACEHOLDER");
        Choices.Add(3, "PLACEHOLDER");
        Choices.Add(4, "PLACEHOLDER");
        Choices.Add(5, "PLACEHOLDER");
        Choices.Add(6, "PLACEHOLDER");
        PS("- ", 30);
        P("");
        int choice = Choose();
        Console.Clear();
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
        Console.Clear();
    }
}
#endregion
#region BusStop1
public class BusStop1 : World
{
    public static void Run()
    {
        ChoiceNumber = 0;
        Choices.Clear();

        Choices.Add(1, "PLACEHOLDER");
        Choices.Add(2, "PLACEHOLDER");
        Choices.Add(3, "PLACEHOLDER");
        Choices.Add(4, "PLACEHOLDER");
        Choices.Add(5, "PLACEHOLDER");
        Choices.Add(6, "PLACEHOLDER");
        PS("- ", 30);
        P("");
        int choice = Choose();
        Console.Clear();
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
        Console.Clear();
    }
}
#endregion
#region BusStop2
public class BusStop2 : World
{
    public static void Run()
    {
        ChoiceNumber = 0;
        Choices.Clear();

        Choices.Add(1, "PLACEHOLDER");
        Choices.Add(2, "PLACEHOLDER");
        Choices.Add(3, "PLACEHOLDER");
        Choices.Add(4, "PLACEHOLDER");
        Choices.Add(5, "PLACEHOLDER");
        Choices.Add(6, "PLACEHOLDER");
        PS("- ", 30);
        P("");
        int choice = Choose();
        Console.Clear();
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
        Console.Clear();
    }
}
#endregion
#region BusStop3
public class BusStop3 : World
{
    public static void Run()
    {
        ChoiceNumber = 0;
        Choices.Clear();

        Choices.Add(1, "PLACEHOLDER");
        Choices.Add(2, "PLACEHOLDER");
        Choices.Add(3, "PLACEHOLDER");
        Choices.Add(4, "PLACEHOLDER");
        Choices.Add(5, "PLACEHOLDER");
        Choices.Add(6, "PLACEHOLDER");
        PS("- ", 30);
        P("");
        int choice = Choose();
        Console.Clear();
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
        Console.Clear();
    }
}
#endregion
#region School
public class School : World
{
    public static void Run()
    {
        ChoiceNumber = 0;
        Choices.Clear();

        Choices.Add(1, "PLACEHOLDER");
        Choices.Add(2, "PLACEHOLDER");
        Choices.Add(3, "PLACEHOLDER");
        Choices.Add(4, "PLACEHOLDER");
        Choices.Add(5, "PLACEHOLDER");
        Choices.Add(6, "PLACEHOLDER");
        PS("- ", 30);
        P("");
        int choice = Choose();
        Console.Clear();
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
        Console.Clear();
    }
}
#endregion
#region Hallway
public class Hallway : World
{
    public static void Run()
    {
        ChoiceNumber = 0;
        Choices.Clear();

        Choices.Add(1, "PLACEHOLDER");
        Choices.Add(2, "PLACEHOLDER");
        Choices.Add(3, "PLACEHOLDER");
        Choices.Add(4, "PLACEHOLDER");
        Choices.Add(5, "PLACEHOLDER");
        Choices.Add(6, "PLACEHOLDER");
        PS("- ", 30);
        P("");
        int choice = Choose();
        Console.Clear();
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
        Console.Clear();
    }
}
#endregion
#region Arcade
public class Arcade : World
{
    public static void Run()
    {
        ChoiceNumber = 0;
        Choices.Clear();

        Choices.Add(1, "PLACEHOLDER");
        Choices.Add(2, "PLACEHOLDER");
        Choices.Add(3, "PLACEHOLDER");
        Choices.Add(4, "PLACEHOLDER");
        Choices.Add(5, "PLACEHOLDER");
        Choices.Add(6, "PLACEHOLDER");
        PS("- ", 30);
        P("");
        int choice = Choose();
        Console.Clear();
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
        Console.Clear();
    }
}
#endregion
#region Playground
public class Playground : World
{
    public static void Run()
    {
        ChoiceNumber = 0;
        Choices.Clear();

        Choices.Add(1, "PLACEHOLDER");
        Choices.Add(2, "PLACEHOLDER");
        Choices.Add(3, "PLACEHOLDER");
        Choices.Add(4, "PLACEHOLDER");
        Choices.Add(5, "PLACEHOLDER");
        Choices.Add(6, "PLACEHOLDER");
        PS("- ", 30);
        P("");
        int choice = Choose();
        Console.Clear();
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
        Console.Clear();
    }
}
#endregion
#region Unknown
public class Unknown : World
{
    public static void Run()
    {
        Console.WriteLine("You shouldn't be here.");
    }
}
#endregion