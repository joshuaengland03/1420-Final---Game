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

        public Save(string name, Room room, int stars)
        {
            PlayerName = name;
            Room = room;
            Stars = stars;
        }

        public Save()
        {

        }
    }

}
