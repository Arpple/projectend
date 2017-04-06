using System.Collections.Generic;
using Entitas;

namespace Game.UI
{
	public class ShareDeckRenderingSystem : ReactiveSystem<CardEntity>
	{
		private readonly CardContainer _shareDeck;

		public ShareDeckRenderingSystem(Contexts contexts, CardContainer shareDeck)
			: base(contexts.card)
		{
			_shareDeck = shareDeck;
		}

		protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
		{
			return new Collector<CardEntity>(
				new[]{
					context.GetGroup(CardMatcher.GameDeckCard),
					context.GetGroup(CardMatcher.GameOwner)
					},
				new[]{
					GroupEvent.Added,
					GroupEvent.Removed
				}
			);
		}

		protected override bool Filter(CardEntity entity)
		{
			return entity.isGameDeckCard && !entity.hasGameOwner;
		}

		protected override void Execute(List<CardEntity> entities)
		{
			foreach (var e in entities)
			{
				_shareDeck.AddCard(e.gameView.GameObject);
			}
		}
	}

}
