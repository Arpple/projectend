using Entitas;
using System.Linq;
using System.Collections.Generic;

namespace End.Game.UI
{
	public class LocalPlayerDeckCardStatusSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		private readonly PlayerUnitStatusPanel _localStatus;

		public LocalPlayerDeckCardStatusSystem(Contexts contexts, PlayerUnitStatusPanel localPlayerStatus) : base(contexts.game)
		{
			_context = contexts.game;
			_localStatus = localPlayerStatus;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.PlayerCard, GroupEvent.AddedOrRemoved);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.playerCard.OwnerEntity.isLocalPlayer;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var deckCardCount = _context.GetEntities(GameMatcher.PlayerCard)
				.Where(e => e.playerCard.OwnerEntity == _context.localPlayerEntity)
				.Count();

			_localStatus.UpdateDeckCardCount(deckCardCount);
		}
	}

}