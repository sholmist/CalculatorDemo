using System;
using Xunit;
using TemperatureConversionDemo;

namespace IndividualAssignmentTests
{
    public class TemperatureConversionDemoTests
    {
        [Theory]
        [InlineData('C', TemperatureUnit.Celcius)]
        public void GetCorrectTemperature(char unit, TemperatureUnit expectedTemperatureUnit)
        {
            Assert.Equal(expectedTemperatureUnit, Temperature.GetTemperatureUnit(unit));
        }
    }
}
