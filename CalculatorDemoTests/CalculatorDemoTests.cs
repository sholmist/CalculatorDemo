using CalculatorDemo;
using System;
using Xunit;

namespace IndividualAssignmentTests
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

        [Fact]
        public void ShouldThrowOnDivisionByZero()
        {
            BasicOperation basicOperations = new BasicOperation(Operator.Divide, decimal.MaxValue, decimal.Zero);

            Assert.Throws<DivideByZeroException>(() => basicOperations.Calculate());
        }

        [Fact]
        public void AdditionShouldThrowOnOverflow()
        {
            BasicOperation additionMax = new BasicOperation(Operator.Add, decimal.MaxValue, decimal.One);
            Assert.Throws<OverflowException>(() => additionMax.Calculate());

            BasicOperation additionMin = new BasicOperation(Operator.Add, decimal.MinValue, decimal.MinusOne);
            Assert.Throws<OverflowException>(() => additionMin.Calculate());
        }

        [Fact]
        public void SubtractionShouldThrowOnOverflow()
        {
            BasicOperation subtractionMax = new BasicOperation(Operator.Subtract, decimal.MaxValue, decimal.MinusOne);
            Assert.Throws<OverflowException>(() => subtractionMax.Calculate());

            BasicOperation subtractionMin = new BasicOperation(Operator.Subtract, decimal.MinValue, decimal.One);
            Assert.Throws<OverflowException>(() => subtractionMin.Calculate());
        }

        [Fact]
        public void MultiplicationShouldThrowOnOverflow()
        {
            BasicOperation multiplicationMax = new BasicOperation(Operator.Multiply, decimal.MaxValue, decimal.MaxValue);
            Assert.Throws<OverflowException>(() => multiplicationMax.Calculate());

            BasicOperation multiplicationMin = new BasicOperation(Operator.Multiply, decimal.MinValue, decimal.MaxValue);
            Assert.Throws<OverflowException>(() => multiplicationMin.Calculate());
        }

        [Fact]
        public void DivisionShouldThrowOnOverflow()
        {
            const decimal value = 0.5m;

            BasicOperation divisionMax = new BasicOperation(Operator.Divide, decimal.MaxValue, value);
            Assert.Throws<OverflowException>(() => divisionMax.Calculate());

            BasicOperation divisionMin = new BasicOperation(Operator.Divide, decimal.MinValue, value);
            Assert.Throws<OverflowException>(() => divisionMin.Calculate());
        }
    }
}