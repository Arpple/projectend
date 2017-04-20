using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherStatusPanel : MonoBehaviour
{
	public WeatherCostObject CostObjectPrefabs;
	public Transform CostObjectParent;
	public Text WeatherNameText;

	private Dictionary<Resource, WeatherCostObject> _costObjects;

	public void Awake()
	{
		_costObjects = new Dictionary<Resource, WeatherCostObject>();
	}

	public void AddCostType(ResourceCardData data)
	{
		var obj = Instantiate(CostObjectPrefabs, CostObjectParent, false);
		obj.SetResourceData(data);
		_costObjects.Add(data.Type, obj);
	}

	public void SetWeatherName(string name)
	{
		WeatherNameText.text = name;
	}

	public void SetCost(Resource type, int cost)
	{
		WeatherCostObject obj;
		if(_costObjects.TryGetValue(type, out obj))
		{
			obj.SetCost(cost);
		}
	}
}
