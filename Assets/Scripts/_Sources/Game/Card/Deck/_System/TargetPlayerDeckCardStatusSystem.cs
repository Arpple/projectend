using Entitas;
using System.Linq;
using System.Collections.Generic;

namespace End.Game.UI
{
	public class TargetPlayerDeckCardStatusUpdateSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		private readonly PlayerUnitStatusPanel _targetStatus;

		public TargetPlayerDeckCardStatusUpdateSystem(Contexts contexts, PlayerUnitStatusPanel targetStatus) : base(contexts.game)
		{
			_context = contexts.game;
			_targetStatus = targetStatus;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.PlayerCard, GroupEvent.AddedOrRemoved);
		}

		protected override bool Filter(GameEntity entity)
		{
			return _targetStatus.ShowingCharacter != null 
				&& entity.playerCard.OwnerEntity == _targetStatus.ShowingCharacter.unit.OwnerEntity;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var deckCardCount = _context.GetEntities(GameMatcher.PlayerCard)
				.Where(e => e.playerCard.OwnerEntity == _targetStatus.ShowingCharacter.unit.OwnerEntity)
				.Count();

			_targetStatus.UpdateDeckCardCount(deckCardCount);
		}
	}

}