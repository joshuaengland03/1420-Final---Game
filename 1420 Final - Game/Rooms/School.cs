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
public class School : Game
{
    public static async Task TypeGame()
    {
        var reflex = new Minigame();
        await reflex.PlayAsync();
    }
    public static async Task Start()
    {
        PS("- You enter the classroom and find your desk.", 30);
        S(1000);
        PS("- You see a new kid walk in and sit next to you.", 30);
        S(1000);
        DS(Default, 1, 40);
        S(1000);
        DS(Default, 2, 40);
        S(1000);
        DS(Default, 3, 40);
        S(1000);
        DS(Finn, 1, 40);
        S(1000);
        PS("- You start to have a conversation when your teacher walks in and class starts.", 30);
        S(2000);
        C();
        DS(Doodle, 1, 40);
        S(1000);
        DS(Doodle, 2, 40);
        S(1000);
        DS(Doodle, 3, 40);
        S(200);
        PS("- You try to pay attention.", 30);
        S(1000);
        PS("- (It's not working very well.)", 30);
        S(1000);
        DS(Finn, 1, 40);
        S(1000);
        DS(Finn, 2, 40);
        S(1000);
        DS(Finn, 3, 40);
        S(1000);
        DS(Finn, 4, 40);
        S(1000);
        DS(Finn, 5, 40);
        S(2000);
        SaveFile.GamePhase = 2;
        C();
        PS("Do you want to play a game with Finn? (Y/N)");
        string userInput = Console.ReadLine().ToLower();
        while (true)
        {
            if (userInput == "y")
            {
                C();
                DS(Finn, 6, 40);
                S(1000);
                DS(Finn, 7, 40);
                S(1000);
                DS(Finn, 8, 40);
                S(1000);
                DS(Finn, 13, 40);
                S(1000);
                DS(Finn, 14, 40);
                S(1000);
                C();
                await TypeGame();
                break;
            }
            else if (userInput == "n")
            {
                C();
                DS(Finn, 11, 40);
                S(2000);
                break;
            }
        }
        C();
        PLS("- The bell rings, ", 600, 30);
        PS("and class ends.", 30);
        S(1000);
        DS(Doodle, 4, 40);
        S(1000);
        DS(Doodle, 5, 40);
        S(2000);
        C();

    }
    public static async Task Run()
    {
        ChoiceNumber = 6;
        Choices.Clear();

        Choices.Add(1, "Play Finn's game");
        Choices.Add(2, "Look around the classroom");
        Choices.Add(3, "Talk to Mr. Doodle");
        Choices.Add(4, "Check the clock");
        Choices.Add(5, "Leave the classroom");
        Choices.Add(6, "Pick up Tape");
        PS("- You are in the classroom");
        P("");
        int choice = Choose();
        Console.Clear();
        switch (choice)
        {
            case 1:
                await TypeGame();
                break;
            case 2:
                PS("- You look around the classroom.", 30);
                S(1000);
                PS("- There are various art projects and inspirational quotes on the walls.", 30);
                S(1000);
                PS("\"Mistakes are proof you're trying... or that you didn’t study.\"", 40);
                S(1000);
                PS("- That doesn't seem very inspiring.", 30);
                S(2000);
                break;
            case 3:
                PS("- You walk up to Mr. Doodle's desk.", 30);
                S(1000);
                PS("- But he seems pretty busy right now.", 30);
                S(2000);
                //TODO ADD DIALOGUE
                break;
            case 4:
                DateTime currentTime = DateTime.Now;
                PLS("- You check the clock on the wall, ", 600, 30);
                PS("it's " + currentTime.ToString("HH:mm tt"), 30);
                S(1000);
                PS("- This clock seems to be broken, too.", 30);
                S(2000);
                break;
            case 5:
                if (SaveFile.DemoFinished == false)
                {
                    PS("You have completed the demo.", 30);
                    S(1000);
                    PS("You are free to explore and find secrets.", 30);
                    S(1000);
                    PS("The full game is coming soon.", 40);
                    S(1000);
                    PS("- You leave the classroom.", 30);
                    S(2000);
                    SaveFile.Room = Room.BusStop2;
                }
                else
                {
                    SaveFile.Room = Room.BusStop2;
                    PS("- You leave the classroom.", 30);
                    S(2000);
                }
                break;
            case 6:
                PS("- You pick up the tape.", 30);
                S(1000);
                PS("- You might need it for later.", 30);
                S(1000);
                SaveFile.Inventory.Add(6, "Roll of Tape");
                PS("(ROLL OF TAPE added to inventory)");
                S(2000);
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