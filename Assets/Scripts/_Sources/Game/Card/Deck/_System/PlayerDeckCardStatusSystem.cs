using Entitas;
using System.Linq;
using System.Collections.Generic;
using End.Game.UI;

namespace End.Game
{
	public class PlayerDeckCardStatusSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		private readonly PlayerStatusPanel _localStatus;

		public PlayerDeckCardStatusSystem(Contexts contexts, PlayerStatusPanel localPlayerStatus) : base(contexts.game)
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
			return true;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var deckCardCount = _context.GetEntities(GameMatcher.PlayerCard)
				.Where(e => e.playerCard.OwnerEntity == _context.localPlayerEntity)
				.Count();

			_localStatus.DeckCardCountText.text = deckCardCount.ToString();
		}
	}

}