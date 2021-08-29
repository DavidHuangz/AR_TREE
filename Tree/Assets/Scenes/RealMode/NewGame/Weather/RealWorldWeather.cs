using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class RealWorldWeather : MonoBehaviour {

	/*
		In order to use this API, you need to register on the website.

		Source: https://openweathermap.org

		Request by city: api.openweathermap.org/data/2.5/weather?q={city id}&appid={your api key}
		Request by lat-long: api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={your api key}

		Api response docs: https://openweathermap.org/current
	*/

	public const string apiKey = "7106733c3aa131c349f678325044e285";

	public string city;
	public bool useLatLng = false;
	public string latitude;
	public string longitude;

	public GameObject weather_GameObject;
	public string weather_txt;

	public GameObject temperature_GameObject;
	public string temperature_txt;

	public GameObject rain_GameObject;
	public string rain_txt;

	void Start()
	{
		city = "Lincoln";
		weather_GameObject.GetComponent<UnityEngine.UI.Text>().text = "Loading...";
		temperature_GameObject.GetComponent<UnityEngine.UI.Text>().text = "Loading...";
		rain_GameObject.GetComponent<UnityEngine.UI.Text>().text = "Loading...";
    }

	public void GetRealWeather () {
		string uri = "https://api.openweathermap.org/data/2.5/weather?";
		if (useLatLng) {
			uri += "lat=" + latitude + "&lon=" + longitude + "&appid=" + apiKey;
		} else {
			uri += "q=" + city + "&appid=" + apiKey;
		}
		StartCoroutine (GetWeatherCoroutine (uri));
	}

	IEnumerator GetWeatherCoroutine (string uri) {
		using (UnityWebRequest webRequest = UnityWebRequest.Get (uri)) {
			yield return webRequest.SendWebRequest ();
			if (webRequest.isNetworkError) {
				Debug.Log ("Web request error: " + webRequest.error);
			} else {
				ParseJson (webRequest.downloadHandler.text);
			}
		}
	}

	WeatherStatus ParseJson (string json) {
		WeatherStatus weather = new WeatherStatus ();
		Root parseWeather = new Root();
		try
		{
			parseWeather = JsonUtility.FromJson<Root>(json); 
			// dynamic obj = JObject.Parse(json);

			weather.weatherId = parseWeather.weather[0].id;
			weather.main = parseWeather.weather[0].main;
			weather.description = parseWeather.weather[0].description;
			weather.temperature = parseWeather.main.temp;
			weather.pressure = parseWeather.main.pressure;
			weather.windSpeed = parseWeather.wind.speed;
			weather.rain = parseWeather.rain._1h;

		}
		catch (Exception e) {
			Debug.Log (e.StackTrace);
		}

/*		Debug.Log("weather: " + weather.main + ": " + weather.description); */
		Debug.Log( parseWeather.rain._1h);

		weather_txt = weather.description;
		weather_GameObject.GetComponent<UnityEngine.UI.Text>().text = weather_txt;

        temperature_txt = weather.Celsius() + "°C";
		temperature_GameObject.GetComponent<UnityEngine.UI.Text>().text = temperature_txt;

		rain_txt = weather.rain.ToString() + "mm";
		rain_GameObject.GetComponent<UnityEngine.UI.Text>().text = rain_txt;

        return weather;
	}
}




