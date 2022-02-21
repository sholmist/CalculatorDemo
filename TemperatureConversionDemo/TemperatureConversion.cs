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

            // Create temperature using users input

            Console.WriteLine("Possible temperatures (K)elvin, (F)arenheit, (C)elcius");
            Console.WriteLine("Write the temperature with the unit it currently is, ex. 40C");

            input = Console.ReadLine().ToUpper();

            currentUnit = input.Last();

            input.Remove(input.Count());

            Temperature temperature = new Temperature(decimal.Parse(input), currentUnit);

            Console.WriteLine("Type the unit you want to convert to.");

            // Convert temperature according to new unit

            newUnit = char.Parse(Console.ReadLine().ToUpper());

            temperature = temperature.ConvertTemperature(temperature, Temperature.GetTemperatureUnit(newUnit));

            // Declare converted temperature

            Console.WriteLine(temperature);
        }
    }
}
