using System.Linq;
using Entitas;
using UnityEngine.Assertions;

namespace Game
{
	public class StartingDeckCardSystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly DeckSetting _setting;

		public StartingDeckCardSystem(Contexts contexts, DeckSetting setting)
		{
			_context = contexts.game;
			_setting = setting;
		}

		public void Initialize()
		{
			var cards = _context.GetEntities(GameMatcher.DeckCard).Shuffle();
			var players = _context.GetEntities(GameMatcher.Player);

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
