namespace EasterEggDemo
{
    public class EasterEggs
    {
        public static bool IsEasterEgg(string input)
        {
            switch (input.ToLower())
            {
                case "xyzzy":
                    Console.WriteLine("Nothing happens");
                    return true;
                case "what's 9+10":
                    Console.WriteLine("21");
                    return true;
                default:
                    return false;
            }
        }
    }
}