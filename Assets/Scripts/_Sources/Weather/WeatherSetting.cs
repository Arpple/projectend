using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeatherSetting : IndexDataList<Weather, WeatherData>
{
	/// <summary>
	/// random weigth for resource count to cost for resolving weather,
	/// index i equals i + 1 count
	/// </summary>
	[Tooltip("random weigth for resource count to cost for resolving weather, index i equals i + 1 count")]
	public List<int> CostCountWeigthList;
}