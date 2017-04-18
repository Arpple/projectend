using System.Collections.Generic;
using Entitas;

public class TurnEndBoxSyncSystem : GameReactiveSystem
{
	private CardContext _cardContext;

	public TurnEndBoxSyncSystem(Contexts contexts) : base(contexts)
	{
		_cardContext = contexts.card;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Playing, GroupEvent.Removed);
	}

	protected override bool Filter(GameEntity entity)
	{
		return !entity.isPlaying && entity.hasPlayerBox && entity.isLocal;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			var sync = new PlayerBoxCardSynchronizer(_cardContext, e);
			sync.Sync();
		}
	}

	private class PlayerBoxCardSynchronizer
	{
		private CardEntity[] _cards;

		public PlayerBoxCardSynchronizer(CardContext context, GameEntity player)
		{
			_cards = context.GetPlayerBoxCards(player);
		}

		public void Sync()
		{
			foreach (var card in _cards)
			{
				EventSyncBoxCard.SyncBoxIndex(card);
			}
		}
	}
}
