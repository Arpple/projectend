using Entitas;

namespace End.Game
{
	[Game]
	public class UnitStatusComponent : IComponent
	{
		public string Name;

		public int HitPoint;
		public int AttackPower;
		public int AttackRange;
		public int VisionRange;
		public int MoveSpeed;
	}
}
