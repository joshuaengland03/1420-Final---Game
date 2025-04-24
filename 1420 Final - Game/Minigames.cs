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

public class Minigame
{
    public async Task PlayAsync()
    {
        PS("Reflex Minigame!");
        PS("Wait for 'GO!' then press ENTER as fast as you can.");
        PS("If you're fast enough, you can earn Finn's prize!");
        PS("Press ENTER to start...");
        Console.ReadLine();

        await RunReflexTestAsync();
    }
    private async Task RunReflexTestAsync()
    {
        var random = new Random();
        int delay = random.Next(2000, 5000);

        PS("Get ready...");
        await Task.Delay(delay);

        P("GO!");

        var time = Stopwatch.StartNew();
        Console.ReadLine();
        time.Stop();

        PS($"Your reaction time: {time.ElapsedMilliseconds} milliseconds");
        S(1000);
        ShowPrize(time.ElapsedMilliseconds);
    }
    private void ShowPrize(long ms)
    {
        if (ms < 200)
        {
            if (SaveFile.ReflexWon == false)
            {
                PS("You are the Fastest! You win a prize");
                S(1000);
                AwardStar();
                SaveFile.ReflexWon = true;
            }
            else
            {
                PS("You are the Fastest, but you already won the prize!");
                S(1000);
            }
        }
        else if (ms < 350)
        {
            PS("Hey, You're pretty fast!");
            S(1000);
            PS("Not fast enough for a prize, but you can try again!");
        }
        else if (ms < 600)
        {
            PS("Not bad!");
            S(1000);
            PS("Not fast enough for a prize, but you can try again!");
        }
        else
        {
            PS("You can do better than that!");
            S(1000);
            PS("If you're fast enough next time, you can win a prize!");
        }

        PS("Press ENTER to finish.");
        Console.ReadLine();
    }

    public static void AwardStar()
    {
        if (SaveFile.Stars == 0)
        {
            PS("- You earned a bronze star!", 30);
            SaveFile.Inventory.Add(3, "Bronze Star");
            PS("(BRONZE STAR added to inventory)");
        }
        else if (SaveFile.Stars == 1)
        {
            PS("- You earned a silver star!", 30);
            SaveFile.Inventory.Add(4, "Silver Star");
            PS("(SILVER STAR added to inventory)");
        }
        else if (SaveFile.Stars == 2)
        {
            PS("- You earned a gold star!", 30);
            SaveFile.Inventory.Add(5, "Gold Star");
            PS("(GOLD STAR added to inventory)");
        }
        else if (SaveFile.Stars >= 3)
        {
            PS("You have everything you need.", 40);
        }
    }
}
