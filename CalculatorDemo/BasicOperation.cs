
namespace CalculatorDemo
{
    public enum Operator { Add, Subtract, Multiply, Divide }

    public class BasicOperation
    {
        readonly Operator Operator;
        readonly decimal Number1;
        readonly decimal Number2;

        public BasicOperation(Operator @operator, decimal num1, decimal num2)
        {
            Operator = @operator;
            Number1 = num1;
            Number2 = num2;
        }

        public BasicOperation AssignOperation(char operation, decimal num1, decimal num2) => operation switch
        {
            '+' => new BasicOperation(Operator.Add, num1, num2),
            '-' => new BasicOperation(Operator.Subtract, num1, num2),
            '*' => new BasicOperation(Operator.Multiply, num1, num2),
            '/' => new BasicOperation(Operator.Divide, num1, num2),
            _ => throw new NotImplementedException("Operation not implemented"),
        };

        public decimal Calculate() => Operator switch
        {
            Operator.Add => Addition(Number1, Number2),
            Operator.Subtract => Subtraction(Number1, Number2),
            Operator.Multiply => Multiplication(Number1, Number2),
            Operator.Divide => Division(Number1, Number2),
            _ => throw new NotImplementedException("Operator not implemented"),
        };

        // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.math?view=net-6.0 om man vill göra en mer komplex miniräknare
        static decimal Addition(decimal num1, decimal num2) => num1 + num2;
        static decimal Subtraction(decimal num1, decimal num2) => num1 - num2;
        static decimal Multiplication(decimal num1, decimal num2) => num1 * num2;
        static decimal Division(decimal num1, decimal num2) => num1 / num2;
    }
}