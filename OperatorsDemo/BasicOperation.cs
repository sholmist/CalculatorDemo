
namespace CalculatorDemo
{
    public enum Operator { Add, Subtract, Multiply, Divide }

    public class BasicOperation
    {
        Operator Operator;
        decimal Number1;
        decimal Number2;

        public BasicOperation(Operator @operator, decimal num1, decimal num2)
        {
            Operator = @operator;
            Number1 = num1;
            Number2 = num2;
        }

        public BasicOperation() { }

        public decimal Calculate()
        {
            switch (Operator)
            {
                case Operator.Add:
                    return Addition(Number1, Number2);
                case Operator.Subtract:
                    return Subtraction(Number1, Number2);
                case Operator.Multiply:
                    return Multiplication(Number1, Number2);
                case Operator.Divide:
                    return Division(Number1, Number2);
                default:
                    throw new ArgumentException("Not a valid operation");
            }
        }

        // TODO: https://docs.microsoft.com/en-us/dotnet/api/system.math?view=net-6.0 om man vill göra en mer komplex miniräknare
        decimal Addition(decimal num1, decimal num2) => num1 + num2;
        decimal Subtraction(decimal num1, decimal num2) => num1 - num2;
        decimal Multiplication(decimal num1, decimal num2) => num1 * num2;
        decimal Division(decimal num1, decimal num2) => num1 / num2;
    }
}