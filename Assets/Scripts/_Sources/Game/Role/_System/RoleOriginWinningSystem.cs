using Entitas;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game
{
	public class RoleOriginWinningSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;

		public RoleOriginWinningSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameDead, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isGameDead && entity.gameUnit.OwnerEntity.gameRole.RoleObject is RoleInvader;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var invaders = _context.GetEntities(GameMatcher.GameRole)
				.Where(r => r.gameRole.RoleObject is RoleInvader);

			if (!invaders.All(i => _context.GetCharacterFromPlayer(i).isGameDead)) return;

			foreach (var o in _context.GetEntities(GameMatcher.GameRole)
				.Where(r => r.gameRole.RoleObject is RoleOrigin))
			{
				o.isGameWin = true;
			}
		}
	}

}
