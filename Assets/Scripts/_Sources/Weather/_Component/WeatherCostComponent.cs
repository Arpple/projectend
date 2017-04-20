using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class WeatherCostComponent : IComponent
{
	public Dictionary<Resource, int> ResourcesCost;
}
