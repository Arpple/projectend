using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unit, Unique]
public class BossUnitComponent : IComponent
{
	public Boss Type;
}

