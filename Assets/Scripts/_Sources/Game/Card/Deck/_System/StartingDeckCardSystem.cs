using System.Linq;
using Entitas;
using UnityEngine.Assertions;
using UnityEngine;

namespace Game
{
	public class StartingDeckCardSystem : IInitializeSystem
	{
		private readonly GameContext _gameContext;
		private readonly CardContext _cardContext;
		private readonly DeckSetting _setting;

		public StartingDeckCardSystem(Contexts contexts, DeckSetting setting)
		{
			_gameContext = contexts.game;
			_cardContext = contexts.card;
			_setting = setting;
		}

		public void Initialize()
		{
			var cards = _cardContext.GetEntities(CardMatcher.GameDeckCard).Shuffle();
			var players = _gameContext.GetEntities(GameMatcher.GamePlayer);

			Assert.IsTrue(players.Count() * _setting.StartCardCount <= cards.Length);

			var i = 0;
			foreach (var p in players)
			{
				_setting.StartCardCount.Loop(() => 
				{
					EventMoveCard.MoveCardToPlayer(cards[i], p);
					i++;
				});
			}
		}
	}
}
