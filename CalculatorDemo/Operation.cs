
namespace CalculatorDemo
{
    public enum Operator { Add, Subtract, Multiply, Divide }

    public class Operation
    {
        readonly Operator Operator;
        readonly decimal Number1;
        readonly decimal Number2;

        public Operation(Operator @operator, decimal num1, decimal num2)
        {
            Operator = @operator;
            Number1 = num1;
            Number2 = num2;
        }

        public static Operation CreateOperation(char operation, decimal num1, decimal num2) => operation switch
        {
            '+' => new Operation(Operator.Add, num1, num2),
            '-' => new Operation(Operator.Subtract, num1, num2),
            '*' => new Operation(Operator.Multiply, num1, num2),
            '/' => new Operation(Operator.Divide, num1, num2),
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

        public static bool operator ==(Operation operation1, Operation operation2)
        {
            if (operation1.Operator == operation2.Operator && 
                operation1.Number1 == operation2.Number1 && 
                operation1.Number2 == operation2.Number2) 
                return true;
            return false;
        }

        public static bool operator !=(Operation operation1, Operation operation2)
        {
            if (operation1.Operator == operation2.Operator &&
                operation1.Number1 == operation2.Number1 &&
                operation1.Number2 == operation2.Number2)
                return false;
            return true;
        }
    }
}