namespace TemperatureConversionDemo
{
    public enum TemperatureUnit { Kelvin = 'K', Farenheit = 'F', Celcius = 'C' }
    public class Temperature
    {
        decimal Value;
        TemperatureUnit TemperatureUnit;

        public Temperature(decimal number, TemperatureUnit temperatureUnit)
        {
            Value = number;
            TemperatureUnit = temperatureUnit;
        }

        public static TemperatureUnit GetTemperatureUnit(char unit)
        {
            switch (unit)
            {
                case 'K':
                    return TemperatureUnit.Kelvin;
                case 'F':
                    return TemperatureUnit.Farenheit;
                case 'C':
                    return TemperatureUnit.Celcius;
                default:
                    throw new ArgumentOutOfRangeException(nameof(unit));
            }
        }

        public void ConvertTemperatureToUnit(TemperatureUnit unit)
        {
            switch (TemperatureUnit)
            {
                case TemperatureUnit.Celcius:
                    ConvertFromCelcius(unit);
                    break;
                case TemperatureUnit.Farenheit:
                    ConvertFromFarenheit(unit);
                    break;
                case TemperatureUnit.Kelvin:
                    ConvertFromKelvin(unit);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown temperature unit");
            }

            TemperatureUnit = unit;
        }

        void ConvertFromCelcius(TemperatureUnit unit)
        {
            switch (unit)
            {
                case TemperatureUnit.Farenheit:
                    Value = Value * 9 / 5 + 32;
                    break;
                case TemperatureUnit.Kelvin:
                    Value += 273.15m;
                    break;
            }
        }

        void ConvertFromFarenheit(TemperatureUnit unit)
        {
            switch (unit)
            {
                case TemperatureUnit.Celcius:
                    Value = Value * 5 / 9 - 32;
                    break;
                case TemperatureUnit.Kelvin:
                    Value = Value * 5 / 9 + 459.67m;
                    break;
            }
        }

        void ConvertFromKelvin(TemperatureUnit unit)
        {
            switch (unit)
            {
                case TemperatureUnit.Celcius:
                    Value -= (decimal)273.15;
                    break;
                case TemperatureUnit.Farenheit:
                    Value = Value * 9 / 5 - 459.67m;
                    break;
            }
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