using Entitas;
using Entitas.CodeGeneration.Attributes;

[Tile]
public class SpawnpointComponent : IComponent
{
	[EntityIndex]
	public int index;
}