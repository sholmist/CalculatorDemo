using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConversionDemo
{
    public static class TemperatureConversion
    {
        public static void Main()
        {
            string input;
            char currentUnit;
            char newUnit;

            Console.WriteLine("Possible temperatures (K)elvin, (F)arenheit, (C)elcius");
            Console.WriteLine("Write the temperature with the unit it currently is, ex. 40C");

            input = Console.ReadLine();

            currentUnit = input.Last();

            

            Console.WriteLine("Type the unit you want to convert to.");

            newUnit = char.Parse(Console.ReadLine());



        }
    }
}
