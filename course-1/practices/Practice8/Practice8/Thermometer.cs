using System;
namespace Practice8
{
	public class Thermometer
	{
		private double _temperatureCelsius;

		public double TemperatureCelsius
		{
			get
			{
				return _temperatureCelsius;
			}

			private set
			{
				if (value < -273.15 || value > 1000)
				{
					Console.WriteLine("Неверный диапазон");
				}
				else {
                    _temperatureCelsius = value;
                }
			}
		}

        public double TemperatureFahrenheit
		{
			set
			{
				TemperatureCelsius = value;
			}
			get
			{
				return _temperatureCelsius * 1.8 + 32;
			}
		}



        public Thermometer()
		{
		}
	}
}

