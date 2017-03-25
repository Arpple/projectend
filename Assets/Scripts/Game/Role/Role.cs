namespace End.Game
{
	public abstract class Role
	{
		public abstract string Name { get; }
		public abstract string Description { get; }
		public abstract string GoalDescription { get; }
		public abstract string IconPath { get; }

		public abstract bool IsWin(GameEntity entity);
	}
}
