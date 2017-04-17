using System.Collections.Generic;
using System.Linq;
using Entitas;

public class PlayerDeckRenderingSystem : ReactiveSystem<CardEntity>
{
	private GameContext _gameContext;
	private CacheList<GameEntity, CardContainer> _playerDeckCache;

	public PlayerDeckRenderingSystem(Contexts contexts)
		: base(contexts.card)
	{
		_gameContext = contexts.game;
		_playerDeckCache = new CacheList<GameEntity, CardContainer>();
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.Owner, GroupEvent.Added);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasOwner && (entity.hasDeckCard || entity.hasResourceCard);
	}

	protected override void Execute(List<CardEntity> entities)
	{
		foreach (var e in entities)
		{
			var deck = _playerDeckCache.Get(e.owner.Entity, (playerEntity) =>
				_gameContext.GetEntities(GameMatcher.PlayerDeck)
					.Where(p => p == playerEntity)
					.First()
					.playerDeck.PlayerDeckObject
			);

			deck.AddCard(e.view.GameObject);
		}
	}
}