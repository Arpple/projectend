using Entitas;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace End.Game
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
			return context.CreateCollector(GameMatcher.Dead, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isDead && entity.unit.OwnerEntity.role.RoleObject is RoleInvader;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var invaders = _context.GetEntities(GameMatcher.Role)
				.Where(r => r.role.RoleObject is RoleInvader);

			if (!invaders.All(i => _context.GetCharacterFromPlayer(i).isDead)) return;

			foreach (var o in _context.GetEntities(GameMatcher.Role)
				.Where(r => r.role.RoleObject is RoleOrigin))
			{
				o.isWin = true;
			}
		}
	}

}
