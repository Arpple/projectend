using System.Collections.Generic;
using Entitas;
using End.Game.UI;

namespace End.Game
{
	public class CreatePlayerDeckSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private CardContainer _cardContainerUI;

		public CreatePlayerDeckSystem(Contexts contexts, CardContainer container)
			: base(contexts.game)
		{
			_cardContainerUI = container;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Player, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasPlayer;
		}

		public void Initialize()
		{
			//create middle deck
			_cardContainerUI.CreateContainer(0);
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				var playerDeck = _cardContainerUI.CreateContainer(e.player.PlayerId);
				e.AddPlayerDeck(playerDeck);
			}
		}
	}

}
