using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class RoundLimitComponent : IComponent
{
	public int Count;
}