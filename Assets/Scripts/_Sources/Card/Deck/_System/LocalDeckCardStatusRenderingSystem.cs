using System.Collections.Generic;
using Entitas;

public class LocalDeckCardStatusRenderingSystem : ReactiveSystem<CardEntity>
{
	private readonly GameContext _gameContext;
	private readonly CardContext _context;
	private readonly PlayerUnitStatusPanel _status;

	public LocalDeckCardStatusRenderingSystem(Contexts contexts, PlayerUnitStatusPanel status) : base(contexts.card)
	{
		_gameContext = contexts.game;
		_context = contexts.card;
		_status = status;
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return new Collector<CardEntity>(
			new[]
			{
					context.GetGroup(CardMatcher.Owner),
					context.GetGroup(CardMatcher.InBox),
			},
			new[]
			{
					GroupEvent.AddedOrRemoved,
					GroupEvent.AddedOrRemoved
			}
		);
	}

	protected override bool Filter(CardEntity entity)
	{
        return (entity.hasDeckCard || entity.hasResourceCard);
	}

	protected override void Execute(List<CardEntity> entities)
	{
		var deckCardCount = _context.GetPlayerDeckCards(_gameContext.localEntity)
			.Length;
        var resouceHandCount = _context.GetPlayerResourceCards(_gameContext.localEntity)
            .Length;
        var boxCardCount = _context.GetPlayerBoxCards(_gameContext.localEntity)
			.Length;
        //UnityEngine.Debug.Log("Card > "+(deckCardCount+resouceHandCount)+","+boxCardCount);
		_status.UpdateDeckCardCount(deckCardCount+resouceHandCount);
		_status.UpdateBoxCardCount(boxCardCount);
	}
}