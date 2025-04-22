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

public class Minigames
{
    public async Task TypeGame()
    {
        Console.WriteLine("Type as many letters as you can in 10 seconds!");
        Console.WriteLine("Go!");

        var inputs = new List<char>();
        var stopwatch = Stopwatch.StartNew();

        var inputTask = Task.Run(() =>
        {
            while (stopwatch.Elapsed < TimeSpan.FromSeconds(10))
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).KeyChar;
                    if (char.IsLetter(key))
                    {
                        inputs.Add(key);
                    }
                }
            }
        });

        await Task.Delay(10000);
        stopwatch.Stop();

        Console.WriteLine($"\nTime's up! You typed {inputs.Count} letters.");

        if (inputs.Count >= 50)
            Console.WriteLine("");
        else if (inputs.Count >= 30)
            Console.WriteLine("");
        else if (inputs.Count >= 10)
            Console.WriteLine("");
        else
            Console.WriteLine("");
    }
}
