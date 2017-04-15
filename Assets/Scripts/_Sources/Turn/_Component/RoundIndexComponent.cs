using Entitas;
using Entitas.CodeGeneration.Attributes;


[Game, Unique]
public class RoundIndexComponent : IComponent
{
	public int Index;
}