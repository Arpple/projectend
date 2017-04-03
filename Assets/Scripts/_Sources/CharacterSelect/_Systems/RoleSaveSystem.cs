using System;
using Entitas;

namespace End.CharacterSelect
{
	public class RoleSaveSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public RoleSaveSystem(Contexts contexts)
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
