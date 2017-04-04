using System.Collections.Generic;
using Entitas;

namespace Game.UI
{
	public class RenderShareDeckSystem : ReactiveSystem<GameEntity>
	{
		private readonly CardContainer _shareDeck;

		public RenderShareDeckSystem(Contexts contexts, CardContainer shareDeck)
			: base(contexts.game)
		{
			_shareDeck = shareDeck;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.PlayerCard, GroupEvent.Removed);
		}

		protected override bool Filter(GameEntity entity)
		{
			return !entity.hasPlayerCard && entity.isDeckCard;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				_shareDeck.AddCard(e.view.GameObject);
			}
		}
	}

}
