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
        PS("- You stand outside on your street");
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
                    PS("- You enter your house", 30);
                    S(2000);
                    SaveFile.Room = Room.LivingRoom;
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
                PS("- You walk to the bus stop", 30);
                S(2000);
                SaveFile.Room = Room.BusStop1;
                break;
            case 4:
                PS("- You look at the strange building.", 30);
                S(1000);
                PS("- It has a strange star-shaped lock.", 30);
                S(1000);
                PS("You are not ready to enter.", 50);
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