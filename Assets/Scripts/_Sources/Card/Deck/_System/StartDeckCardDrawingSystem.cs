using System.Linq;
using Entitas;
using UnityEngine.Assertions;

public class StartDeckCardDrawingSystem : IInitializeSystem
{
	private readonly GameContext _gameContext;
	private readonly CardContext _cardContext;
	private readonly DeckSetting _setting;

	public StartDeckCardDrawingSystem(Contexts contexts, DeckSetting setting)
	{
		_gameContext = contexts.game;
		_cardContext = contexts.card;
		_setting = setting;
	}

	public void Initialize()
	{
		var cards = _cardContext.GetEntities(CardMatcher.DeckCard).Shuffle();
		var players = _gameContext.GetEntities(GameMatcher.Player);

		Assert.IsTrue(players.Count() * _setting.StartCardCount <= cards.Length);

		var i = 0;
		foreach (var p in players)
		{
			_setting.StartCardCount.Loop(() =>
			{
				EventMoveDeckCard.MoveCardToPlayer(cards[i], p);
				i++;
			});
		}
	}
}