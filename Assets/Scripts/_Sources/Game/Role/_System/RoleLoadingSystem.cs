using System;
using Entitas;

namespace Game
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
			foreach (var p in _context.GetEntities(GameMatcher.GamePlayer))
			{
				switch((Role)p.gamePlayer.PlayerObject.RoleId)
				{
					case Role.End:
						p.AddGameRole(new RoleEnd(_context));
					break;

					case Role.Invader:
						p.AddGameRole(new RoleInvader(_context));
					break;

					case Role.Origin:
						p.AddGameRole(new RoleOrigin(_context));
					break;

					case Role.Seed:
						p.AddGameRole(new RoleSeed(_context));
					break;

					default:
						throw new Exception("cannot load role " + p.gamePlayer.PlayerObject.RoleId);
				}
			}
		}
	}
}
