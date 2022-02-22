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

        public static TemperatureUnit GetTemperatureUnit(char tempUnit)
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

        public void ConvertTemperature(TemperatureUnit tempUnit)
        {
            switch (TemperatureUnit)
            {
                case TemperatureUnit.Celcius:
                    switch (tempUnit)
                    {
                        case TemperatureUnit.Farenheit:
                            Value = Value * 9 / 5 + 32;
                            break;
                        case TemperatureUnit.Kelvin:
                            Value += 273.15m;
                            break;
                    }
                    break;
                case TemperatureUnit.Farenheit:
                    switch (tempUnit)
                    {
                        case TemperatureUnit.Celcius:
                            Value = Value * 5 / 9 - 32;
                            break;
                        case TemperatureUnit.Kelvin:
                            Value = Value * 5 / 9 + 459.67m;
                            break;
                    }
                    break;
                case TemperatureUnit.Kelvin:
                    switch (tempUnit)
                    {
                        case TemperatureUnit.Celcius:
                            Value -= (decimal)273.15;
                            break;
                        case TemperatureUnit.Farenheit:
                            Value = Value * 9 / 5 - 459.67m;
                            break;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown temperature unit");
            }

            TemperatureUnit = tempUnit;

        }

        public static bool operator ==(Temperature temp1, Temperature temp2)
        {
            if (temp1.Value == temp2.Value && temp1.TemperatureUnit == temp2.TemperatureUnit)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Temperature temp1, Temperature temp2)
        {
            if (temp1.Value == temp2.Value && temp1.TemperatureUnit == temp2.TemperatureUnit)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"The temperature is {Value} {TemperatureUnit}";
        }
    }
}