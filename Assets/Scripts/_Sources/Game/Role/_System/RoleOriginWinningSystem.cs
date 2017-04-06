using Entitas;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game
{
	public class RoleOriginWinningSystem : ReactiveSystem<UnitEntity>
	{
		private readonly GameContext _gameContext;
		private readonly UnitContext _unitContext;

		public RoleOriginWinningSystem(Contexts contexts) : base(contexts.unit)
		{
			_gameContext = contexts.game;
			_unitContext = contexts.unit;
		}

		protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
		{
			return context.CreateCollector(UnitMatcher.GameDead, GroupEvent.Added);
		}

		protected override bool Filter(UnitEntity entity)
		{
			return entity.isGameDead && entity.gameUnit.OwnerEntity.gameRole.RoleObject is RoleInvader;
		}

		protected override void Execute(List<UnitEntity> entities)
		{
			var invaders = _gameContext.GetEntities(GameMatcher.GameRole)
				.Where(r => r.gameRole.RoleObject is RoleInvader);

			if (!invaders.All(i => _unitContext.GetCharacterFromPlayer(i).isGameDead)) return;

			foreach (var o in _gameContext.GetEntities(GameMatcher.GameRole)
				.Where(r => r.gameRole.RoleObject is RoleOrigin))
			{
				o.isGameWin = true;
			}
		}
	}

}
