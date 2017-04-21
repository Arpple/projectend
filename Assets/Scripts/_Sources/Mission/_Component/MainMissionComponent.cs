using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class MainMissionComponent : IComponent
{
	[EntityIndex]
	public MainMission Type;
}

