using System;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Text.Json;
using static Horizon.Tools;
using Horizon;



class Program
{
    public static string FilePath = "C:/Users/joshua.england1/source/repos/1420 Final - Game/1420 Final - Game/save.json";
    public static Save Save = new Save();
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
                Save.Room = Room.Bedroom;
                Save.PlayerName = "PlayerTest";
                LoadCharacters();
                break;
            }
            else if (userInput == "title")
            {
                Title();
                Save.Room = Room.Bedroom;
                Save.PlayerName = "PlayerTest";
                LoadCharacters();
                break;
            }
            P("Invalid Input. Please type 'Y' or 'N'");
        }


        while (true)
        {
            switch (Save.Room)
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
        Save.PlayerName = input;
        Save.Room = Room.Bedroom;
        LoadCharacters();
        Console.Clear();
        Dialogue.BuildDialogue(Save.PlayerName);
        PS($"\"{Save.PlayerName}\"", 40);
        Thread.Sleep(1000);
        PS("What an interesting name...", 40);
        Thread.Sleep(1500);
        PS($"Well, {Save.PlayerName}, you better wake up.", 40);
        Thread.Sleep(1500);
        PS($"You have things to do.", 40);
        Thread.Sleep(1500);
        Console.Clear();
        Title();
        Thread.Sleep(5000);
        Console.Clear();
        Bedroom.Start();
    }

    public static void LoadCharacters()
    {
        Mom = new Character("Mom", Save.PlayerName);
        Player = new Character("You", Save.PlayerName);
    }

    public static void LoadSave()
    {
        PS("Loading from file...");
        string jsonString = File.ReadAllText(FilePath);
    }

    public static void Title()
    {
        PS("   _____           _   _                 _     _         ");
        PS("  / ____|         | | | |               | |   (_)        ");
        PS(" | |        ___   | | | |   ___    ___  | |_   _    ___  ");
        PS(" | |       / _ \\  | | | |  / _ \\  / __| | __| | |  / _ \\ ");
        PS(" | |____  | (_) | | | | | |  __/ | (__  | |_  | | | (_) |");
        PS("  \\_____|  \\___/  |_| |_|  \\___|  \\___|  \\__| |_|  \\___/ ");
        P("                                                         ");
        PS("By Josh England, 2025", 40);
    }
}