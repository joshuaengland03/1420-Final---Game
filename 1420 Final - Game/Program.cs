namespace Horizon
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Character, Dictionary<int, string>> dialogue = new Dictionary<Character, Dictionary<int, string>>();

            Character bob = new Character("Bob");
            Character tim = new Character("Tim");

            P(bob, 1);
            P(tim, 1);
            P(bob, 2);
            P(tim, 4);
            P(bob, 3);
        }


        public static void P(Character character, int key)
        {
            Console.WriteLine($"{character.Name}: {Dialogue.dialogue[character][key]}");
        }
    }

}