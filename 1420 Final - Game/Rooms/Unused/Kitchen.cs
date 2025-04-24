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