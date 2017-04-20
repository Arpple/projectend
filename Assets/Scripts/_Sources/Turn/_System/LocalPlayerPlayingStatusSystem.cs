using System.Collections.Generic;
using Entitas;

public class LocalPlayerPlayingStatusSystem : GameReactiveSystem
{
	private PlayerUnitStatusPanel _panel;

	public LocalPlayerPlayingStatusSystem(Contexts contexts, PlayerUnitStatusPanel panel) : base(contexts)
	{
		_panel = panel;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Playing, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isLocal;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			_panel.UpdatePlayingTurn(e.isPlaying);
		}
	}
}