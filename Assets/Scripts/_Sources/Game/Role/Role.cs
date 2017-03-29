namespace End.Game
{
	public abstract class Role
	{
		public abstract string Name { get; }
		public abstract string Description { get; }
		public abstract string GoalDescription { get; }
		public abstract string IconPath { get; }

		public virtual bool IsWin(GameContext context, GameEntity entity)
		{
			return !GameUtil.GetCharacterFromPlayer(entity.player.PlayerId).isDead;
		}
	}
}
