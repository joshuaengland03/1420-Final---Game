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
        if (SaveFile.GamePhase == 2)
        {
            ChoiceNumber = 6;
        }
        Choices.Clear();

        Choices.Add(1, "Open the drawer");
        Choices.Add(2, "Look in the mirror");
        Choices.Add(3, "Look under your bed");
        Choices.Add(4, "Check the clock");
        Choices.Add(5, "Leave the room");
        Choices.Add(6, "Go to sleep");
        PS("- You are in the Bedroom");
        P("");
        int choice = Choose();
        C();
        switch (choice)
        {
            case 1:
                if (SaveFile.DrawerOpened == false)
                {
                    if (CheckItem(1))
                    {
                        PS("- You used SMALL KEY.", 30);
                        SaveFile.Inventory.Remove(1);
                        S(1000);
                        PS("- The drawer unlocked!", 30);
                        S(1000);
                        PS("- You find a locket.", 30);
                        PLS("- It has a picture of you as a baby, ", 600, 30);
                        PS("with someone familiar.", 30);
                        S(1500);
                        PS("- You both look happy.", 30);
                        S(2000);
                        SaveFile.Inventory.Add(2, "Locket");
                        SaveFile.DrawerOpened = true;
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
                }
                else
                {
                    PLS("- You opened the drawer, ", 600, 30);
                    PS("but it was empty.", 30);
                    S(2000);
                }
                break;
            case 2:
                if (SaveFile.Stars != 3)
                {
                    PLS("- You look in the mirror. ", 600, 30);
                    PS("It's You!", 30);
                    S(2000);
                }
                else
                {
                    PLS("- You look in the mirror. ", 600, 30);
                    PS("It's You!", 30);
                    S(2000);
                    PS("You are ready to find out the truth.", 40);
                    S(1000);
                    PS("You may enter the lab.", 40);
                    S(1000);
                    PS("Bring the locket.", 40);
                    S(2000);
                }
                break;
            case 3:
                if (SaveFile.BedChecked == true)
                {
                    PLS("- You look under the bed, ", 600, 30);
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
                    SaveFile.BedChecked = true;
                    PS("(SMALL KEY added to inventory)");
                    S(2000);
                }
                break;
            case 4:
                DateTime currentTime = DateTime.Now;
                PLS("- You check the clock, ", 600, 30);
                PS("it's " + currentTime.ToString("HH:mm tt"), 30);
                S(1000);
                PS("- The clock seems to be broken.", 30);
                S(2000);
                break;
            case 5:
                PS("- You leave your Bedroom.", 30);
                S(1000);
                SaveFile.Room = Room.LivingRoom;
                break;
            case 6:
                PS("- You get into bed.", 30);
                S(2000);
                PS("- It was an interesting day.", 30);
                S(2000);
                PS("- You fall asleep.", 30);
                //TODO FINISH AND ADD CREDITS
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
