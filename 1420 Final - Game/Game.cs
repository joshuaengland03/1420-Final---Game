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

public class Game
{
    public static int ChoiceNumber { get; set; }
    public static bool TVTried { get; set; }
    public static Dictionary<int, string> Choices { get; set; } = new Dictionary<int, string>();
    public static Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>
    {
        { "I", "Check Inventory" },
        { "S", "Save Game" },
        { "Q", "Quit" }
    };
    #region CheckItem
    public static bool CheckItem(int id)
    {
        foreach (var item in SaveFile.Inventory)
        {
            if (item.Key == id)
            {
                return true;
            }
            else
            {
                continue;
            }
        }
        return false;
    }
    #endregion
    #region OpenInventory
    public static void OpenInventory()
    {
        Console.Clear();
        P(" ----- INVENTORY ----- ");
        int i = 1;
        foreach (var item in SaveFile.Inventory)
        {
            if (item.Key > 0)
            {
                PS($"{i}: {item.Value}");
                i++;
            }
        }
        P("");
        PS("Press E to exit Inventory");
        while (true)
        {
            string input = Console.ReadLine().ToLower();
            if (input == "e")
            {
                break;
            }
        }
    }
    #endregion
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
    #region SaveToFile
    public static void SaveToFile()
    {
        if (!File.Exists(FilePath))
        {
            File.Create(FilePath).Close();
        }
        try
        {
            string jsonString = JsonSerializer.Serialize(SaveFile, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(FilePath, jsonString);
            PS("Game saved successfully!", 30);
            S(1000);
        }
        catch (Exception ex)
        {
            PS($"Error saving game: {ex.Message}", 30);
        }
    }






    #endregion
    #region QuitGame
    public static void QuitGame()
    {

    }
    #endregion
}
#region Bedroom
public class Bedroom : Game
{
    public static void Start()
    {
        DS(Mom, 1, 40);
        S(1000);
        DS(Mom, 2, 40);
        S(1000);
        DS(Mom, 3, 40);
        S(1000);
        PS("- You get out of bed and get dressed.", 30);
        S(3000);
        C();
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
        C();
        switch (choice)
        {
            case 1:
                if (CheckItem(1))
                {
                    PS("- You used SMALL KEY.", 30);
                    SaveFile.Inventory.Remove(1);
                    S(1000);
                    PS("- The drawer unlocked!", 30);
                    S(1000);
                    PS("- You find a locket.", 30);
                    PLS("- It has a picture of you, ", 600, 30);
                    PS("standing next to someone familiar.", 30);
                    S(1500);
                    PS("- You both look happy.", 30);
                    S(1000);
                    SaveFile.Inventory.Add(2, "Locket");
                    PS("(LOCKET added to inventory)");
                    S(2000);
                }
                else
                {
                    PLS("- You try to open the drawer, ", 600, 30);
                    PS("but it was locked.", 30);
                    S(2000);
                    break;
                }
                break;
            case 2:
                PLS("- You look in the mirror. ", 600, 30);
                PS("It's You!", 30);
                S(2000);
                break;
            case 3:
                if (CheckItem(1))
                {
                    PLS("- You look under the bed again, ", 600, 30);
                    PS("but there was nothing", 30);
                    S(2000);
                    break;
                }
                else
                {
                    PLS("- You look under the bed, ", 600, 30);
                    PS("and you find a small key.", 30);
                    S(500);
                    SaveFile.Inventory.Add(1, "Small Key");
                    PS("(SMALL KEY added to inventory)");
                    S(2000);
                }
                break;
            case 4:
                DateTime currentTime = DateTime.Now;
                PLS("- You check the clock, ", 600, 30);
                PS("it's " + currentTime.ToString("HH:mm tt"), 30);
                S(1000);
                PS("- The clock seems broken.", 30);
                S(2000);
                break;
            case 5:
                PS("- You leave your Bedroom.", 30);
                S(1000);
                SaveFile.Room = Room.LivingRoom;
                break;
            case 11:
                OpenInventory();
                break;
            case 12:
                SaveToFile();
                break;
            case 13:
                QuitGame();
                break;
            default:
                break;
        }
        C();
    }
}
#endregion 
#region LivingRoom
public class LivingRoom : Game
{
    public static void Run()
    {
        ChoiceNumber = 6;
        Choices.Clear();

        Choices.Add(1, "Enter the Bedroom");
        Choices.Add(2, "Enter the Kitchen");
        Choices.Add(3, "Turn on the TV");
        Choices.Add(4, "Use the Bathroom");
        Choices.Add(5, "Look around");
        Choices.Add(6, "Leave the house");
        PS("- You are in the Living Room", 30);
        P("");
        int choice = Choose();
        C();
        switch (choice)
        {
            case 1:
                PS("- You enter your Bedroom.", 30);
                S(1000);
                SaveFile.Room = Room.Bedroom;
                break;
            case 2:
                if (SaveFile.GamePhase == 1)
                {
                    PLS("- You walk to the Kitchen, ", 600, 30);
                    PS("but your mom looks pretty busy.", 30);
                    S(1000);
                    PS("- You decide not to bother her.", 30);
                    S(2000);
                }
                else
                {
                    PS("- You enter the Kitchen.", 30);
                    S(1000);
                    SaveFile.Room = Room.Kitchen;
                    // TODO
                }
                break;
            case 3:
                if (SaveFile.GamePhase == 1)
                {
                    if (TVTried == false)
                    {
                        PS("- You turn on the TV.", 30);
                        S(1000);
                        DS(Mom, 4, 40);
                        S(1000);
                        DS(Mom, 5, 40);
                        S(1000);
                        PS("- You turn off the TV.", 30);
                        S(2000);
                        TVTried = true;
                    }
                    else if (TVTried == true)
                    {
                        PS("- Now is not the time for TV.", 30);
                        S(2000);
                    }
                }
                else
                {
                    PS("- You turn on the TV.", 30);
                    // TODO
                }
                break;
            case 4:
                if (SaveFile.GamePhase == 1)
                {
                    PS("- You knock on the Bathroom door.", 30);
                    S(1000);
                    PS("- It seems like your older sister Mandy is inside.", 30);
                    S(1000);
                    PS("- You hear her favorite artist Dustin Reeber's music playing through the door.", 30);
                    S(1000);
                    DS(Mandy, 1, 40);
                    S(1000);
                    DS(Mandy, 2, 40);
                    S(1000);
                    PS("- You should've used the Bathroom earlier.", 30);
                    S(2000);
                }
                else
                {
                    PS("- You feel no need to enter the Bathroom.", 30);
                }
                    break;
            case 5:
                PS("- You look around the living room.", 30);
                S(1000);
                PS("- There are various family photos from years past.", 30);
                S(1000);
                PLS("- However, ", 600, 30);
                PS("there seems to be something missing.", 30);
                S(1000);
                PS("- You see yourself, your mom, and your sister in each photo.", 30);
                S(1000);
                PS("- Yet something about the photos seems sad.", 30);
                S(2000);
                break;
            case 6:
                if (SaveFile.GamePhase == 1)
                {
                    PS("- You open the door to go to school.", 30);
                    S(1000);
                    DS(Mom, 6, 40);
                    S(1000);
                    DS(Mom, 7, 40);
                    S(1000);
                    PS("- You leave the House.", 30);
                    S(2000);
                    SaveFile.Room = Room.Street;
                }
                else
                {
                    PS("- You leave the House.");
                    SaveFile.Room = Room.Street;
                }
                    break;
            case 11:
                OpenInventory();
                break;
            case 12:
                SaveToFile();
                break;
            case 13:
                QuitGame();
                break;
            default:
                break;
        }
        C();
    }
}
#endregion
#region Kitchen
public class Kitchen : Game
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
public class Street : Game
{
    public static void Run()
    {
        if (SaveFile.GamePhase == 1)
        {
            ChoiceNumber = 3;
        }
        else
        {
            ChoiceNumber = 4;
        }
        Choices.Clear();

        Choices.Add(1, "Enter your house");
        Choices.Add(2, "Look around");
        Choices.Add(3, "Go to the bus stop");
        Choices.Add(4, "Inspect strange building");
        PS("- You stand outside on your street", 30);
        P("");
        int choice = Choose();
        Console.Clear();
        switch (choice)
        {
            case 1:
                if (SaveFile.GamePhase == 1)
                {
                    PS("- You shouldn't go home right now.", 30);
                    S(1000);
                    PS("- You don't want to be late for school.", 30);
                    S(2000);
                }
                else
                {

                }
                    break;
            case 2:
                if (SaveFile.GamePhase == 1)
                {
                    PS("- You look around.", 30);
                    S(1000);
                    PS("- All you see are vacant lots where buildings once existed.", 30);
                    S(1000);
                    PS("- And your house of course.", 30);
                    S(1000);
                    PS("- Not much else to see.", 30);
                    S(2000);
                }
                else if (SaveFile.GamePhase == 2)
                {
                    PS("- You look around.", 30);
                    S(1000);
                    PS("- All you see are vacant lots where buildings once existed.", 30);
                    S(1000);
                    PS("- And your house of course.", 30);
                    S(1000);
                    PS("- Wait, was that large building there before?", 30);
                    S(2000);
                }
                else
                {
                    PS("- You look around.", 30);
                    S(1000);
                    PS("- You see your house, and the large mysterious building.", 30);
                    S(1000);
                    PS("- You swear that it wasn't there before.", 30);
                    S(2000);
                }
                    break;
            case 3:

                break;
            case 4:

                break;
            case 11:
                OpenInventory();
                break;
            case 12:
                SaveToFile();
                break;
            case 13:
                QuitGame();
                break;
            default:
                break;
        }
        Console.Clear();
    }
}
#endregion
#region BusStop1
public class BusStop1 : Game
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
public class BusStop2 : Game
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
public class BusStop3 : Game
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
public class School : Game
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
public class Hallway : Game
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
public class Arcade : Game
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
public class Playground : Game
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
public class Unknown : Game
{
    public static void Run()
    {
        Console.WriteLine("You shouldn't be here.");
    }
}
#endregion