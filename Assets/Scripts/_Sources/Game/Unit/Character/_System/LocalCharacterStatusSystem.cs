using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Linq;

namespace Game.UI
{
	public class LocalCharacterStatusSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly PlayerUnitStatusPanel _ui;

		public LocalCharacterStatusSystem(Contexts contexts, PlayerUnitStatusPanel ui) : base(contexts.game)
		{
			_context = contexts.game;
			_ui = ui;
		}

		public void Initialize()
		{
			_ui.SetCharacter(_context.GetEntities(GameMatcher.GameCharacter)
				.Where(c => c.gameUnit.OwnerEntity.isGameLocalPlayer)
				.First());
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameUnitStatus, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGameUnitStatus && entity.gameUnit.OwnerEntity.isGameLocalPlayer;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var entity in entities)
			{
				_ui.UpdateUnitStatus(entity.gameUnitStatus);
			}
		}
	}

}
