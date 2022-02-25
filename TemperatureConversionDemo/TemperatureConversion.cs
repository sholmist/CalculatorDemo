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
            char inputChar;

            decimal value;
            TemperatureUnit currentUnit;
            TemperatureUnit newUnit;

            // Create temperature using users input

            Console.WriteLine("Possible temperatures (K)elvin, (F)arenheit, (C)elcius");
            Console.WriteLine("Write the temperature with the unit it currently is, ex. 40C");

            input = Console.ReadLine().ToUpper();

            inputChar = input.Last();

            input = input.TrimEnd(inputChar);

            currentUnit = Temperature.GetTemperatureUnit(inputChar);

            value = decimal.Parse(input);

            Temperature temperature = new Temperature(value, currentUnit);

            Console.WriteLine("Type the unit you want to convert to.");

            // Convert temperature according to new unit

            inputChar = char.Parse(Console.ReadLine().ToUpper());

            newUnit = Temperature.GetTemperatureUnit(inputChar);

            temperature.ConvertTemperatureToUnit(newUnit);

            // Declare converted temperature

            Console.WriteLine(temperature);
        }
    }
}
