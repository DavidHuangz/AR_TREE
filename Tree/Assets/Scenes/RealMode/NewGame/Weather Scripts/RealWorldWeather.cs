using System;
using System.Collections;
using Newtonsoft.Json.Linq;
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

	public string apiKey = "7106733c3aa131c349f678325044e285";

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
		weather_GameObject.GetComponent<UnityEngine.UI.Text>().text = "--";
		temperature_GameObject.GetComponent<UnityEngine.UI.Text>().text = "--";
		rain_GameObject.GetComponent<UnityEngine.UI.Text>().text = "--";
    }

	public void GetRealWeather () {
		string uri = "api.openweathermap.org/data/2.5/weather?";
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
		try {
			dynamic obj = JObject.Parse (json);

			weather.weatherId = obj.weather[0].id;
			weather.main = obj.weather[0].main;
			weather.description = obj.weather[0].description;
			weather.temperature = obj.main.temp;
			weather.pressure = obj.main.pressure;
			weather.windSpeed = obj.windSpeed;
		} catch (Exception e) {
			Debug.Log (e.StackTrace);
		}

/*		Debug.Log("weather: " + weather.main + ": " + weather.description);
		Debug.Log("Temp in °C: " + weather.Celsius());*/

		weather_txt = weather.main + ": " + weather.description;
		weather_GameObject.GetComponent<UnityEngine.UI.Text>().text = weather_txt;

        temperature_txt = weather.Celsius() + "°C";
		temperature_GameObject.GetComponent<UnityEngine.UI.Text>().text = temperature_txt;

		rain_txt = weather.windSpeed.ToString();
		rain_GameObject.GetComponent<UnityEngine.UI.Text>().text = rain_txt;

        return weather;
	}
}




