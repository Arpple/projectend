using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine.Assertions;

public class StartDeckCardDrawingSystem : GameReactiveSystem
{
	private readonly GameContext _gameContext;
	private readonly CardContext _cardContext;
	private readonly DeckSetting _setting;
	private readonly GameEventContext _eventContext;

	public StartDeckCardDrawingSystem(Contexts contexts, DeckSetting setting) : base(contexts)
	{
		_gameContext = contexts.game;
		_cardContext = contexts.card;
		_setting = setting;
		_eventContext = contexts.gameEvent;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Round);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasRound && entity.round.Count == 1;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		var players = _gameContext.GetEntities(GameMatcher.Player);
		var movingCards = _eventContext.GetEntities(GameEventMatcher.EventMoveDeckCard)
			.Select(e => e.eventMoveDeckCard.CardEntity);
		var cards = _cardContext.GetEntities(CardMatcher.DeckCard)
			.Except(movingCards)
			.ToArray()
			.Shuffle();

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