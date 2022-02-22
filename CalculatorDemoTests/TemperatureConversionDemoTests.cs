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
        public void GetCorrectTemperature(char unit, TemperatureUnit expectedTemperatureUnit)
        {
            Assert.Equal(expectedTemperatureUnit, Temperature.GetTemperatureUnit(unit));
        }

        [Fact]
        public void GetTemperatureShouldThrowOnInvalidUnit()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Temperature.GetTemperatureUnit('j'));
        }

        [Theory]
        [ClassData(typeof(TemperatureTestData))]
        public void ConvertTemperatureFromUnitToUnit(Temperature temperature, TemperatureUnit temperatureUnit, Temperature expected)
        {
            //Assert.True(expected == temperature.ConvertTemperature(temperatureUnit));
            //Assert.Equal(expected, temperature.ConvertTemperature(temperature, temperatureUnit));
        }
    }
    public class TemperatureTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Temperature(0, 'C'), TemperatureUnit.Farenheit, new Temperature(32, 'F') };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
