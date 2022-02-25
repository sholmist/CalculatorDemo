namespace EasterEggDemo
{
    public static class EasterEggs
    {
        public static bool IsEasterEgg(string input)
        {
            switch (input.ToLower())
            {
                case "xyzzy":
                    Console.WriteLine("Nothing happens");
                    break;
                case "what's 9+10":
                    Console.WriteLine("21");
                    break;
                default:
                    return false;
            }
            Console.ReadKey();
            Console.Clear();
            return true;
        }
    }
}