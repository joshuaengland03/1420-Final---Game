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
public class BusStop1 : Game
{
    public static void Run()
    {
        ChoiceNumber = 6;
        Choices.Clear();

        Choices.Add(1, "Walk to your street");
        Choices.Add(2, "Check bus routes");
        Choices.Add(3, "Wait for bus G32");
        Choices.Add(4, "Wait for bus F04");
        Choices.Add(5, "Look at advertisements");
        Choices.Add(6, "Read newspaper");
        PS("- You are at Bus Stop #1");
        P("");
        int choice = Choose();
        Console.Clear();
        switch (choice)
        {
            case 1:
                if (SaveFile.GamePhase == 1)
                {
                    PS("You can't go back now.", 40);
                    S(1000);
                    PS("- You don't want to miss the bus.", 30);
                    S(2000);
                }
                else
                {
                    PS("- You walk to your street", 30);
                    S(2000);
                    SaveFile.Room = Room.Street;
                }
                break;
            case 2:
                PS("--- Bus Routes ---");
                PS("Bus G32 - Arcade, Commercial District");
                PS("Bus F04 - Rockwell Middle School");
                if (SaveFile.GamePhase == 1)
                {
                    PS("Bus E73 - Residential District (You are Here!)");
                }
                else if (SaveFile.GamePhase == 2)
                {
                    PS("Bus E73 - Residential District, [REDACTED] (You are Here!)");
                }
                else
                {
                    PS("Bus E73 - Residential District, Horizon Labs (You are Here!)");
                }
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
                break;
            case 3:
                if (SaveFile.GamePhase == 1)
                {
                    PS("- You don't have time to go to the arcade yet.", 30);
                    S(2000);
                }
                else
                {
                    PS("- You decide to wait for bus G32.", 30);
                    PS("..........", 700);
                    PLS("- The bus arrives, ", 600, 30);
                    PS("but it's not rideable in this demo.", 30);
                    S(2000);
                }
                break;
            case 4:
                PS("- You decide to wait for bus F04.", 30);
                PS("..........", 700);
                PLS("- The bus arrives, ", 600, 30);
                PS("and you enter.", 30);
                S(2000);
                SaveFile.Room = Room.BusStop2;
                break;
            case 5:
                PS("- You look at the advertisements.", 30);
                S(1000);
                PS("*   NEW - JOAN'S BBQ & FOOT MASSAGE   *");
                PS("*    GET RICH QUICK - SUMMER SALES    *");
                PS("*   CALL FOR A GOOD TIME - 555-8008   *");
                S(2000);
                PS("- Not much to see.", 30);
                S(2000);
                break;
            case 6:
                PS("- You pick up a newspaper.", 30);
                S(1500);
                Newspaper();
                C();
                PS("- That's strange.", 30);
                S(1000);
                PS("- It's dated months after you were born.", 30);
                S(1000);
                PS("- What's a newspaper so old doing here?", 30);
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