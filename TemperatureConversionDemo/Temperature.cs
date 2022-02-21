namespace TemperatureConversionDemo
{
    public enum TemperatureUnit { Kelvin = 'K', Farenheit = 'F', Celcius = 'C' }
    public class Temperature
    {
        decimal Value;
        TemperatureUnit TemperatureUnit;

        public Temperature(decimal number, char temperatureUnit)
        {
            Value = number;
            TemperatureUnit = GetTemperatureUnit(temperatureUnit);
        }

        public TemperatureUnit GetTemperatureUnit(char tempUnit)
        {
            switch (tempUnit)
            {
                case 'K':
                    return TemperatureUnit.Kelvin;
                case 'F':
                    return TemperatureUnit.Farenheit;
                case 'C':
                    return TemperatureUnit.Celcius;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tempUnit));
            }
        }

        public Temperature ConvertTemperature(Temperature temperature, TemperatureUnit tempUnit)
        {
            switch (temperature.TemperatureUnit)
            {
                case TemperatureUnit.Celcius:
                    switch (tempUnit)
                    {
                        case TemperatureUnit.Farenheit:
                            temperature.Value *= 9/5 + 32;
                            break;
                        case TemperatureUnit.Kelvin:
                            temperature.Value += (decimal)273.15;
                            break;
                    }
                    break;
                case TemperatureUnit.Farenheit:
                    switch (tempUnit)
                    {
                        case TemperatureUnit.Celcius:
                            temperature.Value *= 5/9 - 32;
                            break;
                        case TemperatureUnit.Kelvin:
                            temperature.Value *= 5/9 + (decimal)459.67;
                            break;
                    }
                    break;
                case TemperatureUnit.Kelvin:
                    switch (tempUnit)
                    {
                        case TemperatureUnit.Celcius:
                            temperature.Value -= (decimal)273.15;
                            break;
                        case TemperatureUnit.Farenheit:
                            temperature.Value *= 9 / 5 - (decimal)459.67;
                            break;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown temperature unit");
            }

            temperature.TemperatureUnit = tempUnit;

            return temperature;
        }
    }
}