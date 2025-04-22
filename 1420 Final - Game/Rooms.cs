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
        if (SaveFile.GamePhase == 3)
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
#endregion
#region Kitchen
//UNUSED
public class Kitchen : Game
{
    public static void Run()
    {
        ChoiceNumber = 4;
        Choices.Clear();

        Choices.Add(1, "UNFINISHED");
        Choices.Add(2, "WORK IN PROGRESS");
        Choices.Add(3, "COMING SOON");
        Choices.Add(4, "GO TO BEDROOM");
        Choices.Add(5, "PLACEHOLDER");
        Choices.Add(6, "PLACEHOLDER");
        PS("- You shouldn't be here. ");
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
                SaveFile.Room = Room.Bedroom;
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
                //TODO
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
                    PS("and you enter.", 30);
                    S(2000);
                    SaveFile.Room = Room.BusStop3;
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
#endregion
#region BusStop2
public class BusStop2 : Game
{
    public static void Run()
    {
        ChoiceNumber = 6;
        Choices.Clear();

        Choices.Add(1, "Walk to school");
        Choices.Add(2, "Check bus routes");
        Choices.Add(3, "Wait for bus G32");
        Choices.Add(4, "Wait for bus E73");
        Choices.Add(5, "Look at advertisements");
        Choices.Add(6, "Read newspaper");
        PS("- You are at Bus Stop #1");
        P("");
        int choice = Choose();
        Console.Clear();
        switch (choice)
        {
            case 1:
                PS("- You walk inside the school.", 30);
                break;
            case 2:
                PS("--- Bus Routes ---");
                PS("Bus G32 - Arcade, Commercial District");
                PS("Bus F04 - Rockwell Middle School (You are Here!)");
                if (SaveFile.GamePhase == 1)
                {
                    PS("Bus E73 - Residential District");
                }
                else if (SaveFile.GamePhase == 2)
                {
                    PS("Bus E73 - Residential District, [REDACTED]");
                }
                else
                {
                    PS("Bus E73 - Residential District, Horizon Labs");
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
                    PS("and you enter.", 30);
                    S(2000);
                    SaveFile.Room = Room.BusStop3;
                }
                break;
            case 4:
                PS("- You decide to wait for bus E73.", 30);
                PS("..........", 700);
                PLS("- The bus arrives, ", 600, 30);
                PS("and you enter.", 30);
                S(2000);
                SaveFile.Room = Room.BusStop1;
                break;
            case 5:
                PS("- You look at the advertisements.", 30);
                S(1000);
                PS("*     REVENGERS MIDGAME -- NOW IN THEATERS     *");
                PS("*    JOE'S ICE CREAM PARLOR AND BARBER SHOP    *");
                PS("*       GOT WORMS? JAMES'S EXTERMINATION       *");
                S(2000);
                PS("- Not much to see.", 30);
                S(2000);
                break;
            case 6:
                PS("- You pick up a newspaper.", 30);
                S(1500);
                Newspaper();
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
#region BusStop3
public class BusStop3 : Game
{
    public static void Run()
    {
        ChoiceNumber = 6;
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
    public static void Start()
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
        S(1000);
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
                //TODO TYPING GAME
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
        PS("and class ends.");
        S(1000);
        DS(Doodle, 4, 40);
        S(1000);
        DS(Doodle, 5, 40);
        S(2000);
        C();

    }
    public static void Run()
    {
        ChoiceNumber = 5;
        Choices.Clear();

        Choices.Add(1, "Play Finn's game");
        Choices.Add(2, "Look around the classroom");
        Choices.Add(3, "Talk to Mr. Doodle");
        Choices.Add(4, "Check the clock");
        Choices.Add(5, "Pick up tape");
        Choices.Add(6, "Leave the classroom");
        PS("- You are in the classroom");
        P("");
        int choice = Choose();
        Console.Clear();
        switch (choice)
        {
            case 1:
                //TODO TYPING GAME
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
                //TODO FINISH
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

                break;
            case 6:

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