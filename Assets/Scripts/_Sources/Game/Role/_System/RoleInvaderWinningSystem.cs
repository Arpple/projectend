using Entitas;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game
{
	public class RoleInvaderWinningSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;

		public RoleInvaderWinningSystem(Contexts contexts) : base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameDead, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isGameDead && entity.gameUnit.OwnerEntity.gameRole.RoleObject is RoleOrigin;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var origins = _context.GetEntities(GameMatcher.GameRole)
				.Where(r => r.gameRole.RoleObject is RoleOrigin);

			if (!origins.All(i => _context.GetCharacterFromPlayer(i).isGameDead)) return;

			foreach (var i in _context.GetEntities(GameMatcher.GameRole)
				.Where(r => r.gameRole.RoleObject is RoleInvader))
			{
				i.isGameWin = true;
			}
		}
	}

}
