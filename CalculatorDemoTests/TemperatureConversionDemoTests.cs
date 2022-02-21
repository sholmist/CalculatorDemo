using System;
using Xunit;
using TemperatureConversionDemo;

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
    }
}
