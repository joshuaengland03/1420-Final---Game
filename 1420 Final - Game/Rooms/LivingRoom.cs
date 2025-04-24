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

public class LivingRoom : Game
{
    public static void Run()
    {
        ChoiceNumber = 6;
        Choices.Clear();

        Choices.Add(1, "Enter the Bedroom");
        Choices.Add(2, "Enter the Kitchen");
        if (TVOn == false)
        {
            Choices.Add(3, "Turn on the TV");
        }
        else
        {
            Choices.Add(3, "Turn off the TV");
        }
        Choices.Add(4, "Use the Bathroom");
        Choices.Add(5, "Look around");
        Choices.Add(6, "Leave the house");
        PS("- You are in the Living Room");
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
                    PS("- She's been fixing the oven for a few days now with no luck.", 30);
                    S(1000);
                    PS("- You decide not to bother her.", 30);
                    S(2000);
                }
                else
                {
                    PLS("- You go to enter the kitchen, ", 600, 30);
                    PS("but it's pretty messy.", 30);
                    S(1000);
                    PS("- Whatever your mom was doing before, it seems unfinished.", 30);
                    S(2000);
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
                    if (TVOn == false)
                    {
                        PS("- You turn on the TV.", 30);
                        S(2000);
                    }
                    else
                    {
                        PS("- You turn off the TV.", 30);
                        S(2000);
                    }
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
