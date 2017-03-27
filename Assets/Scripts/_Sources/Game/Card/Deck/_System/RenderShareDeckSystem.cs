using System.Collections.Generic;
using Entitas;
using End.Game.UI;

namespace End.Game
{
	public class RenderShareDeckSystem : ReactiveSystem<GameEntity>
	{
		private readonly PlayerDeck _shareDeck;

		public RenderShareDeckSystem(Contexts contexts, PlayerDeck shareDeck)
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
			return !entity.hasPlayerCard;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				UnityEngine.Debug.Log(e.view.GameObject);
				_shareDeck.AddCard(e.view.GameObject);
			}
		}
	}

}
