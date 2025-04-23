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

        Console.WriteLine("GO!");

        var stopwatch = Stopwatch.StartNew();
        Console.ReadLine();
        stopwatch.Stop();

        PS($"Your reaction time: {stopwatch.ElapsedMilliseconds} milliseconds");
        S(1000);
        ShowPrize(stopwatch.ElapsedMilliseconds);
    }
    private void ShowPrize(long ms)
    {
        if (ms < 200)
            PS("You are the Fastest!");
        else if (ms < 350)
            PS("Hey, You're pretty fast!");
        else if (ms < 600)
            PS("Not bad!");
        else
            PS("You can do better than that!");

        PS("Press ENTER to finish.");
        Console.ReadLine();
    }
}
