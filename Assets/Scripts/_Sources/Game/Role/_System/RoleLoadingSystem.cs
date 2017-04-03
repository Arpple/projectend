using System;
using Entitas;

namespace End.Game
{
	public class RoleLoadingSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public RoleLoadingSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			foreach (var p in _context.GetEntities(GameMatcher.Player))
			{
				switch((Role)p.player.PlayerObject.RoleId)
				{
					case Role.End:
						p.AddRole(new RoleEnd(_context));
					break;

					case Role.Invader:
						p.AddRole(new RoleInvader(_context));
					break;

					case Role.Origin:
						p.AddRole(new RoleOrigin(_context));
					break;

					case Role.Seed:
						p.AddRole(new RoleSeed(_context));
					break;

					default:
						throw new Exception("cannot load role " + p.player.PlayerObject.RoleId);
				}
			}
		}
	}
}
