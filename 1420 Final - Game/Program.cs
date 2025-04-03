using System;
using static System.Net.Mime.MediaTypeNames;
using static Horizon.Tools;
using Horizon;



class Program
{
    public static Save File = new Save();
    public static Character Mom;
    public static Character Player;
    public static void Main(string[] args)
    {
        string userInput = "";



        // TODO: Load save file "File" from a json file if the user needs it to
        P("Would you like to start from a save point? (Y/N)");
        while (true)
        {
            userInput = Console.ReadLine().ToLower();
            if (userInput == "y")
            {
                LoadSave();
                PS("Loading Done");
                break;
            }
            else if (userInput == "n")
            {
                PS("Initializing...       ", 75);
                InitializeNew();
                break;
            }
            else if (userInput == "t")
            {
                PS("TEST MODE ENABLED", 1);
                File.Room = Room.Bedroom;
                File.PlayerName = "PlayerTest";
                break;
            }
            else if (userInput == "title")
            {
                Title();
                File.Room = Room.Bedroom;
                File.PlayerName = "PlayerTest";
                break;
            }
            P("Invalid Input. Please type 'Y' or 'N'");
        }

        Mom = new Character("Mom", File.PlayerName);
        Player = new Character("You", File.PlayerName);

        while (true)
        {
            switch (File.Room)
            {
                case Room.Bedroom:
                    Bedroom.Run();
                    break;
                case Room.LivingRoom:
                    LivingRoom.Run();
                    break;
                case Room.Kitchen:
                    Kitchen.Run();
                    break;
                case Room.Street:
                    Street.Run();
                    break;
                case Room.BusStop1:
                    BusStop1.Run();
                    break;
                case Room.BusStop2:
                    BusStop2.Run();
                    break;
                case Room.BusStop3:
                    BusStop3.Run();
                    break;
                case Room.School:
                    School.Run();
                    break;
                case Room.Hallway:
                    Hallway.Run();
                    break;
                case Room.Arcade:
                    Arcade.Run();
                    break;
                case Room.Playground:
                    Playground.Run();
                    break;
                case Room.Unknown:
                    Unknown.Run();
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }
    }




    public static void InitializeNew()
    {
        Console.Clear();
        PS("What is your name?", 40);
        string input = Console.ReadLine();
        File.PlayerName = input;
        File.Room = Room.Bedroom;
        Console.Clear();
        Dialogue.BuildDialogue(File.PlayerName);
        PS($"\"{File.PlayerName}\"", 40);
        Thread.Sleep(1000);
        PS("What an interesting name...", 40);
        Thread.Sleep(1500);
        PS($"Well, {File.PlayerName}, you better wake up.", 40);
        Thread.Sleep(1500);
        PS($"You have things to do.", 40);
        Thread.Sleep(1500);
        Console.Clear();
        Title();
        Thread.Sleep(5000);
        Console.Clear();
        DS(Mom, 1, 40);
        Thread.Sleep(1000);
        DS(Mom, 2, 40);
        Thread.Sleep(1000);
        DS(Mom, 3, 40);
    }

    public static void LoadSave()
    {
        PS("Loading from file...");
    }
    public static void Title()
    {
        PS("  _____                       _    __          __  _____   _____  ");
        PS(" |  ___| (_)                 | |   \\ \\        / / |_   _| |  __ \\ ");
        PS(" | |__    _   _ __     __ _  | |    \\ \\  /\\  / /    | |   | |__) |");
        PS(" |  __|  | | | '_ \\   / _` | | |     \\ \\/  \\/ /     | |   |  ___/ ");
        PS(" | |     | | | | | | | (_| | | |      \\  /\\  /     _| |_  | |     ");
        PS(" |_|     |_| |_| |_|  \\__,_| |_|       \\/  \\/     |_____| |_|     ");
        P("");
        PS("By Josh England, 2025", 40);
    }
}