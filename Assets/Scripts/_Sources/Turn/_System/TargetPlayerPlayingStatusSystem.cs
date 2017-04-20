using System.Collections.Generic;
using Entitas;

public class TargetPlayerPlayingStatusSystem : GameReactiveSystem
{
	private PlayerUnitStatusPanel _panel;
	private UnitContext _unitContext;

	public TargetPlayerPlayingStatusSystem(Contexts contexts, PlayerUnitStatusPanel panel) : base(contexts)
	{
		_panel = panel;
		_unitContext = contexts.unit;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Playing, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(GameEntity entity)
	{
		return _panel.ShowingCharacter == _unitContext.GetEntityOwnedBy(entity);
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			_panel.UpdatePlayingTurn(e.isPlaying);
		}
	}
}