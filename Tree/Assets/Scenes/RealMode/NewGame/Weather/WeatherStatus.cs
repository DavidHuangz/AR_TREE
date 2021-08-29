// Conditions explained: https://openweathermap.org/weather-conditions

 public class WeatherStatus {
	 public int weatherId;
	 public string main;
	 public string description;
	 public double temperature; // in kelvin
	 public double pressure;
	 public double windSpeed;
	 public double rain;

	 public float Celsius () {
		return (int)(temperature - 273.15f);
	}

	 public float Fahrenheit () {
		return Celsius () * 9.0f / 5.0f + 32.0f;
	}

}