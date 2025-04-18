using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Horizon
{
    public static class Dialogue
    {
        public static Dictionary<string, Dictionary<int, string>> Dialogues = new Dictionary<string, Dictionary<int, string>>();

        public static void BuildDialogue(string name)
        {

            Dialogues["Mom"] = new Dictionary<int, string>
            {
                { 1, $"{name}!" },
                { 2, "Wake up!" },
                { 3, "You'll be late for school!" },
                { 4, "Honey! You need to get to school!" },
                { 5, "Turn off the TV or you'll be late!" },
                { 6, $"Bye {name}!" },
                { 7, "Have a great day at school!" },
                { 8, "" },
                { 9, "" },
                { 10, "" },
                { 11, "" },
                { 12, "" },
                { 13, "" },
                { 14, "" },
                { 15, "" },
                { 16, "" },
            };

            Dialogues["???"] = new Dictionary<int, string>
            {
                { 1, "Hi!" },
                { 2, "I'm new around here." },
                { 3, "Nice to meet you!" },
                { 4, "" }
            };

            Dialogues["Mandy"] = new Dictionary<int, string>
            {
                { 1, $"{name}! Leave me alone!" },
                { 2, "I need to get ready too, you know!" },
                { 3, "" },
                { 4, "" },
            };

            Dialogues["Finn"] = new Dictionary<int, string>
            {
                { 1, "My name is Finn." },
                { 2, "Hey, I never asked." },
                { 3, "What is your name?" },
                { 2, $"{name}? Awesome!" },
                { 3, "Hey, do you want to play a game?" },
                { 2, "It's called Higher & Lower!" },
                { 3, "I'm going to choose a number " },
                { 2, "" },
                { 3, "" },
                { 2, "" },
                { 3, "" },
            };

            Dialogues["Mr. Doodle"] = new Dictionary<int, string>
            {
                { 1, "Welcome Class!" },
                { 2, "Everyone find your seats." },
                { 3, "Today, we are going to start... " },
                { 4, "" },
                { 5, "" },
                { 6, "" },
                { 7, "" },
                { 8, "" }
            };
        }


        public static Dictionary<int, string> GetDialogue(string name, string playerName)
        {
            BuildDialogue(playerName);
            return Dialogues[name];
        }
   

    }
}

