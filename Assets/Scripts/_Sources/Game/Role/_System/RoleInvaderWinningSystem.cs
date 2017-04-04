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
			return context.CreateCollector(GameMatcher.Dead, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isDead && entity.unit.OwnerEntity.role.RoleObject is RoleOrigin;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var origins = _context.GetEntities(GameMatcher.Role)
				.Where(r => r.role.RoleObject is RoleOrigin);

			if (!origins.All(i => _context.GetCharacterFromPlayer(i).isDead)) return;

			foreach (var i in _context.GetEntities(GameMatcher.Role)
				.Where(r => r.role.RoleObject is RoleInvader))
			{
				i.isWin = true;
			}
		}
	}

}
