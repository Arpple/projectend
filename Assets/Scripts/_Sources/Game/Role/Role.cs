using UnityEngine.Assertions;

namespace End.Game
{
	public enum Role
	{
		Origin,
		Invader,
		End,
		Seed,
	}

	public abstract class RoleObject
	{
		public abstract string Name { get; }
		public abstract string Description { get; }
		public abstract string GoalDescription { get; }
		public abstract string IconPath { get; }
		public abstract Role Type { get; }

		protected GameContext _context;

		public RoleObject(GameContext context)
		{
			_context = context;
		}
	}
}
