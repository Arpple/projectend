using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

namespace Game
{
	public class StartTurnDrawSystem : ReactiveSystem<GameEntity>
	{
		private CardContext _cardContext;
		private DeckSetting _setting;

		public StartTurnDrawSystem(Contexts contexts, DeckSetting setting) : base(contexts.game)
		{
			_cardContext = contexts.card;
			_setting = setting;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GamePlaying);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isGamePlaying && entity.isGameLocal;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				var cards = _cardContext.GetShareDeckCards().Shuffle();
				if(cards.Length > 0)
				{
					var drawCards = cards.Take(Math.Min(cards.Length, _setting.StartTurnDrawCount));
					foreach(var c in drawCards)
					{
						EventMoveCard.MoveCardToPlayer(c, e);
					}
				}
			}
		}
	}
}
