using UnityEngine.Assertions;

namespace End.Game
{
	public abstract class Role
	{
		public abstract string Name { get; }
		public abstract string Description { get; }
		public abstract string GoalDescription { get; }
		public abstract string IconPath { get; }

		protected GameContext _context;

		public Role(GameContext context)
		{
			_context = context;
		}

		//public virtual bool IsWin(GameEntity playerEntity)
		//{
		//	Assert.IsTrue(playerEntity.hasPlayer);

		//	return !GameUtil.GetCharacterFromPlayer(playerEntity).isDead;
		//}
	}
}
