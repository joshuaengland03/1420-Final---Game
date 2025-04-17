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
                { 4, "My name is Finn." }
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
                { 1, "" },
                { 2, ""},
                { 3, ""},
            };
        }


        public static Dictionary<int, string> GetDialogue(string name, string playerName)
        {
            BuildDialogue(playerName);
            return Dialogues[name];
        }
   

    }
}

