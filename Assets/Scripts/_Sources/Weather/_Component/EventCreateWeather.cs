using System.Collections.Generic;

[GameEvent]
public class EventCreateWeather : GameEventComponent
{
	public Weather Type;
	public Dictionary<Resource, int> CostMap;

	public static void Create(Weather type, Dictionary<Resource, int> costMap)
	{
		GameEvent.CreateEvent<EventCreateWeather>(
			(int)type,
			costMap[Resource.Wood],
			costMap[Resource.Water],
			costMap[Resource.Coal]
		);
	}

	public void Decode(int typeId, int woodCost, int waterCost, int coalCost)
	{
		Type = (Weather)typeId;
		CostMap = new Dictionary<Resource, int>
		{
			{ Resource.Wood, woodCost },
			{ Resource.Water, waterCost },
			{ Resource.Coal, coalCost }
		};
	}
}
