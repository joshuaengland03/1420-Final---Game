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

public class Game
{
    public static int ChoiceNumber { get; set; }
    public static bool TVTried { get; set; }
    public static bool TVOn { get; set; }
    public static Dictionary<int, string> Choices { get; set; } = new Dictionary<int, string>();
    public static Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>
    {
        { "I", "Check Inventory" },
        { "S", "Save Game" },
        { "Q", "Quit" }
    };
    #region CheckItem
    public static bool CheckItem(int id)
    {
        foreach (var item in SaveFile.Inventory)
        {
            if (item.Key == id)
            {
                return true;
            }
            else
            {
                continue;
            }
        }
        return false;
    }
    #endregion
    #region OpenInventory
    public static void OpenInventory()
    {
        Console.Clear();
        P(" ----- INVENTORY ----- ");
        int i = 1;
        foreach (var item in SaveFile.Inventory)
        {
            if (item.Key > 0)
            {
                PS($"{i}: {item.Value}");
                i++;
            }
        }
        P("");
        PS("Press E to exit Inventory");
        while (true)
        {
            string input = Console.ReadLine().ToLower();
            if (input == "e")
            {
                break;
            }
        }
    }
    #endregion
    #region Choose
    public static int Choose()
    {
        foreach (var choice in Choices)
        {
            if (choice.Key > ChoiceNumber)
            {
                break;
            }
            else
            {
                PS($"{choice.Key}: {choice.Value}");
            }
        }
        P("");
        foreach (var option in Options)
        {
            PS($"{option.Key}: {option.Value}");
        }
        P("");
        while (true)
        {
            string input = Console.ReadLine().ToLower();
            if (int.TryParse(input, out int number))
            {
                if (number <= ChoiceNumber && number > 0)
                {
                    return number;
                }
                else
                {
                    P("Number invalid. Try again.");
                }
            }
            else
            {
                if (input == "i")
                {
                    return 11;
                }
                else if (input == "s")
                {
                    return 12;
                }
                else if (input == "q")
                {
                    return 13;
                }
                else
                {
                    P("Option invalid. Try again.");
                }
            }
        }
    }
    #endregion
    #region SaveToFile
    public static void SaveToFile()
    {
        if (!File.Exists(FilePath))
        {
            File.Create(FilePath).Close();
        }
        try
        {
            string jsonString = JsonSerializer.Serialize(SaveFile, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(FilePath, jsonString);
            PS("Game saved successfully!", 30);
            S(1000);
        }
        catch (Exception ex)
        {
            PS($"Error saving game: {ex.Message}", 30);
        }
    }

    #endregion
    #region QuitGame
    public static void QuitGame()
    {
        P("------- Quit -------");
        P("");
        PS("1. Save and Quit");
        PS("2. Quit without Saving");
        PS("3. Back");

        while (true)
        {
            string input = Console.ReadLine().ToLower();
            if (input == "1")
            {
                SaveToFile();
                Environment.Exit(1);
            }
            else if (input == "2")
            {
                Environment.Exit(1);
            }
            else if (input == "3")
            {
                break;
            }
        }
    }
    #endregion
}

