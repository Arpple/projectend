using System.Collections.Generic;
using Entitas;

namespace Game.UI
{
	public class RenderShareDeckSystem : ReactiveSystem<CardEntity>
	{
		private readonly CardContainer _shareDeck;

		public RenderShareDeckSystem(Contexts contexts, CardContainer shareDeck)
			: base(contexts.card)
		{
			_shareDeck = shareDeck;
		}

		protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
		{
			return context.CreateCollector(CardMatcher.GameOwner, GroupEvent.Removed);
		}

		protected override bool Filter(CardEntity entity)
		{
			return !entity.hasGameOwner && entity.isGameDeckCard;
		}

		protected override void Execute(List<CardEntity> entities)
		{
			foreach(var e in entities)
			{
				_shareDeck.AddCard(e.gameView.GameObject);
			}
		}
	}

}
