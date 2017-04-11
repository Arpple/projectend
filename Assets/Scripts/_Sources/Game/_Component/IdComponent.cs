using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Tile, Card, Unit]
public class IdComponent : IComponent
{
	[EntityIndex]
	public int Id;
}
