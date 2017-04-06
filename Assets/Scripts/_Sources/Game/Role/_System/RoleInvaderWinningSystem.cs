using Entitas;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Game
{
	public class RoleInvaderWinningSystem : ReactiveSystem<UnitEntity>
	{
		private readonly GameContext _gameContext;
		private readonly UnitContext _unitContext;

		public RoleInvaderWinningSystem(Contexts contexts) : base(contexts.unit)
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
			return entity.isGameDead && entity.gameOwner.Entity.gameRole.RoleObject is RoleOrigin;
		}

		protected override void Execute(List<UnitEntity> entities)
		{
			var origins = _gameContext.GetEntities(GameMatcher.GameRole)
				.Where(r => r.gameRole.RoleObject is RoleOrigin);

			if (!origins.All(i => _unitContext.GetCharacterFromPlayer(i).isGameDead)) return;

			foreach (var i in _gameContext.GetEntities(GameMatcher.GameRole)
				.Where(r => r.gameRole.RoleObject is RoleInvader))
			{
				i.isGameWinner = true;
			}
		}
	}

}
