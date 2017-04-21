using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class PlayerMissionComponent : IComponent
{
	[EntityIndex]
	public PlayerMission MisisonType;
}