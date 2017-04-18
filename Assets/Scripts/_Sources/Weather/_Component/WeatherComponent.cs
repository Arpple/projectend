using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class WeatherComponent : IComponent
{
	public Weather Type;
}
