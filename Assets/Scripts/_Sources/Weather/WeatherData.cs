using UnityEngine;

[CreateAssetMenu(menuName = "End/Weather", fileName = "new_weather.asset")]
public class WeatherData : ScriptableObject, IIndexData<Weather>
{
	public Weather Type;
	public Resource Cost;

	public Weather GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(Weather index)
	{
		return Type == index;
	}
}