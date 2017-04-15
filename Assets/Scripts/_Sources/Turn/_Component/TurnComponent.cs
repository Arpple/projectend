using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class TurnComponent : IComponent
{
	public int Count;
}