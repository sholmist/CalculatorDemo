using Xunit;
using CalculatorDemo;
using System;

namespace CalculatorDemoTests
{
    public class CalculatorDemoTests
    {
        [Theory]
        [InlineData(1,2)]
        [InlineData(-3,4)]
        [InlineData(5.4,-6)]
        [InlineData(-2, -4.93)]
        //[InlineData(decimal.MinValue, decimal.MaxValue)]
        public void AdditionOperationTest(decimal num1, decimal num2)
        {
            BasicOperation basicOperations = new BasicOperation(Operator.Add, num1, num2);
            decimal result = basicOperations.Calculate();
            Assert.Equal(num1 + num2, result);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(-3, 4)]
        [InlineData(5.4, -6)]
        [InlineData(-2, -4.93)]
        public void SubtractionOperationTest(decimal num1, decimal num2)
        {
            BasicOperation basicOperations = new BasicOperation(Operator.Subtract, num1, num2);
            decimal result = basicOperations.Calculate();
            Assert.Equal(num1 - num2, result);
        }

        // TODO: Testa om det går över double max och min value
        [Theory]
        [InlineData(1, 2)]
        [InlineData(-3, 4)]
        [InlineData(5.4, -6)]
        [InlineData(-2, -4.93)]
        public void MultiplicationOperationTest(decimal num1, decimal num2)
        {
            BasicOperation basicOperations = new BasicOperation(Operator.Multiply, num1, num2);
            decimal result = basicOperations.Calculate();
            Assert.Equal(num1 * num2, result);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(-3, 4)]
        [InlineData(5.4, -6)]
        [InlineData(-2, -4.93)]
        [InlineData(2, 0)]
        public void DivisionOperationTest(decimal num1, decimal num2)
        {
            BasicOperation basicOperations = new BasicOperation(Operator.Divide, num1, num2);
            decimal result = basicOperations.Calculate();
            Assert.Equal(num1 / num2, result);

            // Test how method handles division by 0

        }
    }
}