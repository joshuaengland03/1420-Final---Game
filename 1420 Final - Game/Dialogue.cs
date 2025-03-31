using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon
{
    class Dialogue
    {
        public static Dictionary<Character, Dictionary<int, string>> dialogue = new Dictionary<Character, Dictionary<int, string>>();

        static Dialogue()
        {
            Character bob = new Character("Bob");
            Character tim = new Character("Tim");



            dialogue[bob] = new Dictionary<int, string>
            {
                { 1, "Hello!" },
                { 2, "How are you?" },
                { 3, "That's Great!" },
                { 4, "Awesome!" }
            };

            dialogue[tim] = new Dictionary<int, string>
            {
                { 1, "Hello!" },
                { 2, "How are you?" },
                { 3, "That's Great!" },
                { 4, "Awesome!" }
            };
        }
    }
}

