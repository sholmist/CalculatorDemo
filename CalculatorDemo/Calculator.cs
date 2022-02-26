using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasterEggDemo;
using TemperatureConversionDemo;

namespace CalculatorDemo
{
    public static class Calculator
    {
        public static void Main()
        {
            // TODO: initera basicoperations
            Operation operation;

            string input;
            char @operator = ' ';
            decimal[] numbers;
            bool repeat = true;

            while (repeat == true)
            {
                try
                {
                    // TODO: ta in operation i form av 2*2 
                    Console.WriteLine("What would you like to calculate?\nExample: 2*3");
                    Console.WriteLine("If you want to convert to Farenheit/Celcius, type 'convert'.");
                    Console.WriteLine("Type 'quit' to exit");

                    input = Console.ReadLine();

                    switch (input.ToLower())
                    {
                        case "quit":
                            repeat = false;
                            continue;
                        case "convert":
                            TemperatureConversion.Main();
                            continue;
                    }

                    if (EasterEggs.IsEasterEgg(input) == true)
                        continue;


                    // TODO: hämta rätt operation
                    input = input.Trim();
                    @operator = input.ToList().Find(x => char.IsDigit(x) == false);

                    numbers = input.Split(@operator).Select(decimal.Parse).ToArray();
                    //Console.WriteLine(String.Join(",", numbers));

                    operation = Operation.CreateOperation(@operator, numbers[0], numbers[1]);

                    decimal result = operation.Calculate();

                    // TODO: skriv ut resultat
                    Console.WriteLine($"{input} = {result}");

                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Do not divide by 0");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Result/numbers too large to calculate");
                }
                catch (NotImplementedException)
                {
                    Console.WriteLine($"'{@operator}' is not an operator");
                }
                catch
                {
                    Console.WriteLine("Please type a valid calculation");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
