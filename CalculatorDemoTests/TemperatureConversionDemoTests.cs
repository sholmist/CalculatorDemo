using System;
using Xunit;
using TemperatureConversionDemo;
using System.Collections;
using System.Collections.Generic;

namespace IndividualAssignmentTests
{
    public class TemperatureConversionDemoTests
    {
        [Theory]
        [InlineData('C', TemperatureUnit.Celcius)]
        [InlineData('F', TemperatureUnit.Farenheit)]
        [InlineData('K', TemperatureUnit.Kelvin)]
        public void ShouldGetTemperatureUnit(char unit, TemperatureUnit expectedTemperatureUnit)
        {
            Assert.Equal(expectedTemperatureUnit, Temperature.GetTemperatureUnit(unit));
        }

        [Fact]
        public void ShouldThrowOnInvalidTemperatureUnit()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Temperature.GetTemperatureUnit('j'));
        }

        // TODO Test for override == != VETTIGARE
        [Theory]
        [ClassData(typeof(EqualToTestData))]
        public void EqualToOverrideShouldReturnExpectedValue(Temperature temp1, Temperature temp2, bool expected)
        {
            Assert.Equal(expected, temp1 == temp2);
        }

        [Theory]
        [ClassData(typeof(NotEqualToTestData))]
        public void NotEqualToOverrideShouldReturnExpectedValue(Temperature temp1, Temperature temp2, bool expected)
        {
            Assert.Equal(expected, temp1 != temp2);
        }

        [Theory]
        [ClassData(typeof(ConvertTemperatureTestData))]
        public void ShouldConvertTemperatureFromUnitToUnit(Temperature temperature, TemperatureUnit temperatureUnit, Temperature expected)
        {
            Assert.True(expected != temperature);
            //Assert.Equal(expected, temperature.ConvertTemperature(temperature, temperatureUnit));
            temperature.ConvertTemperature(temperatureUnit);
            Assert.True(expected == temperature);
        }

    }
    public class ConvertTemperatureTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Temperature(decimal.Zero, 'C'), TemperatureUnit.Farenheit, new Temperature(32, 'F') };
            yield return new object[] { new Temperature(-132, 'C'), TemperatureUnit.Farenheit, new Temperature(-205.6m, 'F') };
            yield return new object[] { new Temperature(132, 'C'), TemperatureUnit.Farenheit, new Temperature(269.6m, 'F') };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class EqualToTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Temperature(decimal.Zero, 'C'), new Temperature(decimal.Zero, 'C'), true };
            yield return new object[] { new Temperature(decimal.Zero, 'F'), new Temperature(-205.6m, 'F'), false };
            yield return new object[] { new Temperature(132, 'C'), new Temperature(132, 'F'), false };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class NotEqualToTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Temperature(decimal.Zero, 'C'), new Temperature(decimal.Zero, 'C'), false };
            yield return new object[] { new Temperature(decimal.Zero, 'F'), new Temperature(-205.6m, 'F'), true };
            yield return new object[] { new Temperature(132, 'C'), new Temperature(132, 'F'), true };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
