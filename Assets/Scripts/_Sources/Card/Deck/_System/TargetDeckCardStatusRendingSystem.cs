using System.Collections.Generic;
using Entitas;

public class TargetDeckCardStatusRendingSystem : ReactiveSystem<CardEntity>
{
	private readonly CardContext _context;
	private readonly PlayerUnitStatusPanel _status;

	public TargetDeckCardStatusRendingSystem(Contexts contexts, PlayerUnitStatusPanel status) : base(contexts.card)
	{
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
		return _status.ShowingCharacter != null;
	}

	protected override void Execute(List<CardEntity> entities)
	{
		var deckCardCount = _context.GetPlayerDeckCards(_status.ShowingCharacter.owner.Entity)
			.Length;
		var boxCardCount = _context.GetPlayerBoxComponentCards(_status.ShowingCharacter.owner.Entity)
			.Length;

		_status.UpdateDeckCardCount(deckCardCount);
		_status.UpdateBoxCardCount(boxCardCount);
	}
}