using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon
{
    public class Save
    {
        public string PlayerName { get; set; }
        public Room Room { get; set; }
        public int Stars { get; set; }
        public int GamePhase { get; set; }
        public Dictionary<int, string> Inventory { get; set; } = new Dictionary<int, string>()
        {
            { 0, "null" }
        };

        public Save
            (
            string name,
            Room room,
            int stars,
            Dictionary<int, string> inventory,
            int gamePhase
            )

        {
            PlayerName = name;
            Room = room;
            Stars = stars;
            Inventory = inventory;
            GamePhase = gamePhase;
        }

        public Save()
        {

        }
    }

}
