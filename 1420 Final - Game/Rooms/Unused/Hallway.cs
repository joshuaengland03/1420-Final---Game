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