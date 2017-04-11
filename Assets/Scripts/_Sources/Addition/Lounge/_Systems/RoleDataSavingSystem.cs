using System;
using Entitas;

namespace Lounge
{
	public class RoleDataSavingSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public RoleDataSavingSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			foreach(var p in _context.GetEntities(GameMatcher.Player))
			{
				p.player.PlayerObject.CmdSetRole((int)p.role.RoleObject.Type);
			}
		}
	}
}
