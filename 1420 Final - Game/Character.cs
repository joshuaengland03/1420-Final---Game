using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Horizon
{
    public class Character
    {
        public string Name { get; set; }
        public Dictionary<int, string> CDialogue { get; set; }

        public Character(string name, string playerName)
        {
            Name = name;
            CDialogue = Dialogue.GetDialogue(name, playerName);
        }
    }
}
