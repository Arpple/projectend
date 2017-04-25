using UnityEngine;

[CreateAssetMenu(menuName = "End/Weather", fileName = "new_weather.asset")]
public class WeatherData : ScriptableObject, IIndexData<Weather>
{
	public Weather Type;
	public string Name;
	public Resource Cost;
    public WeatherChangeEffect WeatherEffect;

	public Weather GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(Weather index)
	{
		return Type == index;
	}
}