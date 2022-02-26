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
        [ClassData(typeof(EqualToTemperatureTestData))]
        public void EqualToShouldReturnExpected(Temperature temp1, Temperature temp2, bool expected)
        {
            Assert.Equal(expected, temp1 == temp2);
        }

        [Theory]
        [ClassData(typeof(NotEqualToTemperatureTestData))]
        public void NotEqualToShouldReturnExpected(Temperature temp1, Temperature temp2, bool expected)
        {
            Assert.Equal(expected, temp1 != temp2);
        }

        [Theory]
        [ClassData(typeof(ConvertTemperatureTestData))]
        public void ShouldConvertTemperatureFromUnitToUnit(Temperature temperature, TemperatureUnit temperatureUnit, Temperature expected)
        {
            Assert.True(expected != temperature);
            //Assert.Equal(expected, temperature.ConvertTemperature(temperature, temperatureUnit));
            temperature.ConvertTemperatureToUnit(temperatureUnit);
            Assert.True(expected == temperature);
        }

    }
    public class ConvertTemperatureTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 
                new Temperature(decimal.Zero, TemperatureUnit.Celcius), 
                TemperatureUnit.Farenheit, 
                new Temperature(32, TemperatureUnit.Farenheit) };
            yield return new object[] { 
                new Temperature(-132, TemperatureUnit.Celcius), 
                TemperatureUnit.Farenheit, 
                new Temperature(-205.6m, TemperatureUnit.Farenheit) };
            yield return new object[] { 
                new Temperature(132, TemperatureUnit.Celcius), 
                TemperatureUnit.Farenheit, 
                new Temperature(269.6m, TemperatureUnit.Farenheit) };

        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class EqualToTemperatureTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new Temperature(decimal.Zero, TemperatureUnit.Celcius),
                new Temperature(decimal.Zero, TemperatureUnit.Celcius),
                true };
            yield return new object[] { 
                new Temperature(decimal.Zero, TemperatureUnit.Celcius), 
                new Temperature(decimal.Zero, TemperatureUnit.Farenheit), 
                false };
            yield return new object[] { 
                new Temperature(decimal.Zero, TemperatureUnit.Farenheit), 
                new Temperature(decimal.Zero, TemperatureUnit.Kelvin), 
                false };
            yield return new object[] { 
                new Temperature(decimal.Zero, TemperatureUnit.Kelvin), 
                new Temperature(decimal.Zero, TemperatureUnit.Celcius), 
                false };
            yield return new object[] { 
                new Temperature(decimal.Zero, TemperatureUnit.Farenheit), 
                new Temperature(decimal.One, TemperatureUnit.Farenheit), 
                false };
            yield return new object[] { 
                new Temperature(decimal.One, TemperatureUnit.Farenheit), 
                new Temperature(decimal.Zero, TemperatureUnit.Farenheit), 
                false };
            yield return new object[] {
                new Temperature(decimal.MaxValue, TemperatureUnit.Farenheit),
                new Temperature(decimal.MinValue, TemperatureUnit.Farenheit),
                false };
            yield return new object[] {
                new Temperature(decimal.MinValue, TemperatureUnit.Farenheit),
                new Temperature(decimal.MaxValue, TemperatureUnit.Farenheit),
                false };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class NotEqualToTemperatureTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new Temperature(decimal.Zero, TemperatureUnit.Celcius),
                new Temperature(decimal.Zero, TemperatureUnit.Celcius),
                false };
            yield return new object[] {
                new Temperature(decimal.Zero, TemperatureUnit.Celcius),
                new Temperature(decimal.Zero, TemperatureUnit.Farenheit),
                true };
            yield return new object[] {
                new Temperature(decimal.Zero, TemperatureUnit.Farenheit),
                new Temperature(decimal.Zero, TemperatureUnit.Kelvin),
                true };
            yield return new object[] {
                new Temperature(decimal.Zero, TemperatureUnit.Kelvin),
                new Temperature(decimal.Zero, TemperatureUnit.Celcius),
                true };
            yield return new object[] {
                new Temperature(decimal.Zero, TemperatureUnit.Farenheit),
                new Temperature(decimal.One, TemperatureUnit.Farenheit),
                true };
            yield return new object[] {
                new Temperature(decimal.One, TemperatureUnit.Farenheit),
                new Temperature(decimal.Zero, TemperatureUnit.Farenheit),
                true };
            yield return new object[] {
                new Temperature(decimal.MaxValue, TemperatureUnit.Farenheit),
                new Temperature(decimal.MinValue, TemperatureUnit.Farenheit),
                true };
            yield return new object[] {
                new Temperature(decimal.MinValue, TemperatureUnit.Farenheit),
                new Temperature(decimal.MaxValue, TemperatureUnit.Farenheit),
                true };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
