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
        public static Room Room { get; set; }
        public int Stars { get; set; }
        public static Dictionary<int, string> Inventory = new Dictionary<int, string>()
        {
            { 0, "null" }
        };
        public static bool SchoolDone { get; set; }

        public Save
            (
            string name,
            Room room,
            int stars,
            Dictionary<int, string> inventory,
            bool schoolDone
            )

        {
            PlayerName = name;
            Room = room;
            Stars = stars;
            Inventory = inventory;
            SchoolDone = schoolDone;
        }

        public Save()
        {

        }
    }

}
