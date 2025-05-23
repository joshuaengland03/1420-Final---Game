﻿using System;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Text.Json;
using static Horizon.Tools;
using Horizon;



class Program
{
    public static string FilePath = "save.json";
    public static Save SaveFile = new Save();
    public static int Mode { get; set; } // 0 - Normal, 1 - Debug, 2 - Test
    public static Character Mom;
    public static Character Default;
    public static Character Mandy;
    public static Character Finn;
    public static Character Doodle;
    public static async Task Main(string[] args)
    {
        string userInput = "";
        Mode = 0;
        P("Would you like to start from a save point? (Y/N)");
        while (true)
        {
            userInput = Console.ReadLine().ToLower();
            if (userInput == "y")
            {
                LoadSave();
                PS("Loading Done");
                S(1000);
                C();
                break;
            }
            else if (userInput == "n")
            {
                C();
                PS("Initializing...", 120);
                S(1000);
                Begin();
                break;
            }
            else if (userInput == "d")
            {
                C();
                Mode = 1;
                InitializeVar();
                LoadCharacters();
                break;
            }
            else if (userInput == "t")
            {
                Mode = 2;
                C();
                InitializeVar();
                LoadCharacters();
                break;
            }
            else if (userInput == "title")
            {
                Title();
                S(5000);
                Environment.Exit(0);
                break;
            }
            P("Invalid Input. Please type 'Y' or 'N'");
        }


        while (true)
        {
            switch (SaveFile.Room)
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
                    if (SaveFile.GamePhase == 1)
                    {
                        await School.Start();
                    }
                    else
                    {
                        await School.Run();
                    }
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



    public static void Begin()
    {
        C();
        InitializeVar();
        LoadCharacters();
        Dialogue.BuildDialogue(SaveFile.PlayerName);
        PS($"\"{SaveFile.PlayerName}\"", 40);
        S(1000);
        PS("What an interesting name...", 40);
        S(1500);
        PS($"Well, {SaveFile.PlayerName}, you better wake up.", 40);
        S(1500);
        PS($"You have things to do.", 40);
        S(1500);
        C();
        Title();
        S(5000);
        C();
        Bedroom.Start();
    }

    public static void InitializeVar()
    {
        SaveFile.GamePhase = 1;
        PS("What is your name?", 40);
        string input = Console.ReadLine();
        SaveFile.PlayerName = input;
        SaveFile.Room = Room.Bedroom;
        SaveFile.BedChecked = false;
        SaveFile.DrawerOpened = false;
        SaveFile.PapersChecked = 0;
        SaveFile.ReflexWon = false;
        SaveFile.DemoFinished = false;
        Game.TVTried = false;
        Game.TVOn = false;
        C();
    }

    public static void LoadCharacters()
    {
        Default = new Character("???", SaveFile.PlayerName);
        Mom = new Character("Mom", SaveFile.PlayerName);
        Mandy = new Character("Mandy", SaveFile.PlayerName);
        Finn = new Character("Finn", SaveFile.PlayerName);
        Doodle = new Character("Mr. Doodle", SaveFile.PlayerName);
    }

    public static void LoadSave()
    {
        if (!File.Exists(FilePath))
        {
            PS("Save data does not exist.");
            S(1000);
            PS("Initializing new file...", 100);
            S(1000);
            Begin();
        }
        else
        {
            PS("Loading from file...");
            string jsonString = File.ReadAllText(FilePath);
            SaveFile = JsonSerializer.Deserialize<Save>(jsonString);
            LoadCharacters();
        }
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