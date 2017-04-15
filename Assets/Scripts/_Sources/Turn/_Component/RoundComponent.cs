using Entitas;
using Entitas.CodeGeneration.Attributes;


[Game, Unique]
public class RoundComponent : IComponent
{
	public int Count;
}