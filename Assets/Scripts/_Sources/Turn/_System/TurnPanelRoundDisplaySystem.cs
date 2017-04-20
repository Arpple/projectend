using System.Collections.Generic;
using Entitas;

public class TurnPanelRoundDisplaySystem : GameReactiveSystem
{
	private TurnPanel _panel;

	public TurnPanelRoundDisplaySystem(Contexts contexts, TurnPanel panel) : base(contexts)
	{
		_panel = panel;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return new Collector<GameEntity>
		(
			new[]
			{
				context.GetGroup(GameMatcher.Round),
				context.GetGroup(GameMatcher.RoundLimit)
			},
			new[]
			{
				GroupEvent.Added,
				GroupEvent.Added,
			}
		);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasRound || entity.hasRoundLimit;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			var round = _context.hasRound
				? _context.round.Count
				: 0;

			var roundLimit = _context.hasRoundLimit
				? _context.roundLimit.Count
				: 0;

			_panel.UpdateRoundText(round, roundLimit);
		}
	}
}