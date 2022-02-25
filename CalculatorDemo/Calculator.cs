using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasterEggDemo;

namespace CalculatorDemo
{
    public static class Calculator
    {
        public static void Main()
        {
            // TODO: initera basicoperations
            BasicOperation basicOperation;
            string input;
            char operation = ' ';
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
                            continue;
                    }

                    if (EasterEggs.IsEasterEgg(input) == true)
                        continue;


                    // TODO: hämta rätt operation
                    input = input.Trim();
                    operation = input.ToList().Find(x => char.IsDigit(x) == false);

                    numbers = input.Split(operation).Select(decimal.Parse).ToArray();
                    //Console.WriteLine(String.Join(",", numbers));

                    switch (operation)
                    {
                        case '+':
                            basicOperation = new BasicOperation(Operator.Add, numbers[0], numbers[1]);
                            break;
                        case '-':
                            basicOperation = new BasicOperation(Operator.Subtract, numbers[0], numbers[1]);
                            break;
                        case '*':
                            basicOperation = new BasicOperation(Operator.Multiply, numbers[0], numbers[1]);
                            break;
                        case '/':
                            basicOperation = new BasicOperation(Operator.Divide, numbers[0], numbers[1]);
                            break;
                        default:
                            throw new NotImplementedException("Unknown operator");
                    }

                    decimal result = basicOperation.Calculate();

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
                    Console.WriteLine($"'{operation}' is not an operator");
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
