using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon
{
    public class World
    {

    }

    public class Bedroom : World
    {
        public static void Run()
        {
            Console.WriteLine("You are in the Bedroom");
        }
    }

    public class LivingRoom : World
    {
        public static void Run()
        {
            Console.WriteLine("You are in the Living Room");
        }
    }

    public class Kitchen : World
    {
        public static void Run()
        {
            Console.WriteLine("You are in the Kitchen");
        }
    }

    public class Street : World
    {
        public static void Run()
        {
            Console.WriteLine("You are in the Street");
        }
    }

    public class BusStop1 : World
    {
        public static void Run()
        {
            Console.WriteLine("You are at Bus Stop G24");
        }
    }

    public class BusStop2 : World
    {
        public static void Run()
        {
            Console.WriteLine("You are at Bus Stop L12");
        }
    }

    public class BusStop3 : World
    {
        public static void Run()
        {
            Console.WriteLine("You are at Bus Stop B72");
        }
    }

    public class School : World
    {
        public static void Run()
        {
            Console.WriteLine("You are at School");
        }
    }

    public class Hallway : World
    {
        public static void Run()
        {
            Console.WriteLine("You are in the Hallway");
        }
    }

    public class Arcade : World
    {
        public static void Run()
        {
            Console.WriteLine("You are at the Arcade");
        }
    }

    public class Playground : World
    {
        public static void Run()
        {
            Console.WriteLine("You are at the school Playground");
        }
    }

    public class Unknown : World
    {
        public static void Run()
        {
            Console.WriteLine("You shouldn't be here.");
        }
    }
}
