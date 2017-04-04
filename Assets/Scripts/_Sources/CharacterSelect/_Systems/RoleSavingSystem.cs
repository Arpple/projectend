using System;
using Entitas;

namespace CharacterSelect
{
	public class RoleSavingSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public RoleSavingSystem(Contexts contexts)
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
