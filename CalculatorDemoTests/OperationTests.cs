using CalculatorDemo;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace IndividualAssignmentTests
{
    public class OperationTests
    {
        [Theory]
        [ClassData(typeof(ExpectedOperationTestData))]
        public void ShouldCreateExpectedOperation(char C, decimal num1, decimal num2, Operation expected)
        {
            Assert.True(expected == Operation.CreateOperation(C, num1, num2));
        }


        [Theory]
        [InlineData(1,2)]
        [InlineData(-3,4)]
        [InlineData(5.4,-6)]
        [InlineData(-2, -4.93)]
        public void AdditionOperationTest(decimal num1, decimal num2)
        {
            Operation basicOperations = new Operation(Operator.Add, num1, num2);
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
            Operation basicOperations = new Operation(Operator.Subtract, num1, num2);
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
            Operation basicOperations = new Operation(Operator.Multiply, num1, num2);
            decimal result = basicOperations.Calculate();
            Assert.Equal(num1 * num2, result);
        }

        [Fact]
        public void ShouldThrowOnDivisionByZero()
        {
            Operation basicOperations = new Operation(Operator.Divide, decimal.MaxValue, decimal.Zero);

            Assert.Throws<DivideByZeroException>(() => basicOperations.Calculate());
        }

        [Fact]
        public void AdditionShouldThrowOnOverflow()
        {
            Operation additionMax = new Operation(Operator.Add, decimal.MaxValue, decimal.One);
            Assert.Throws<OverflowException>(() => additionMax.Calculate());

            Operation additionMin = new Operation(Operator.Add, decimal.MinValue, decimal.MinusOne);
            Assert.Throws<OverflowException>(() => additionMin.Calculate());
        }

        [Fact]
        public void SubtractionShouldThrowOnOverflow()
        {
            Operation subtractionMax = new Operation(Operator.Subtract, decimal.MaxValue, decimal.MinusOne);
            Assert.Throws<OverflowException>(() => subtractionMax.Calculate());

            Operation subtractionMin = new Operation(Operator.Subtract, decimal.MinValue, decimal.One);
            Assert.Throws<OverflowException>(() => subtractionMin.Calculate());
        }

        [Fact]
        public void MultiplicationShouldThrowOnOverflow()
        {
            Operation multiplicationMax = new Operation(Operator.Multiply, decimal.MaxValue, decimal.MaxValue);
            Assert.Throws<OverflowException>(() => multiplicationMax.Calculate());

            Operation multiplicationMin = new Operation(Operator.Multiply, decimal.MinValue, decimal.MaxValue);
            Assert.Throws<OverflowException>(() => multiplicationMin.Calculate());
        }

        [Fact]
        public void DivisionShouldThrowOnOverflow()
        {
            const decimal value = 0.5m;

            Operation divisionMax = new Operation(Operator.Divide, decimal.MaxValue, value);
            Assert.Throws<OverflowException>(() => divisionMax.Calculate());

            Operation divisionMin = new Operation(Operator.Divide, decimal.MinValue, value);
            Assert.Throws<OverflowException>(() => divisionMin.Calculate());
        }
    }
    public class ExpectedOperationTestData : IEnumerable<object[]>
    {
        const decimal Value = decimal.One;
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { '+', Value, Value ,
                    new Operation(Operator.Add, Value, Value) };
            yield return new object[] { '-', Value, Value,
                    new Operation(Operator.Subtract, Value, Value) };
            yield return new object[] { '*', Value, Value,
                    new Operation(Operator.Multiply, Value, Value) };
            yield return new object[] { '/', Value, Value,
                    new Operation(Operator.Divide, Value, Value) };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}