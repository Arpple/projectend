using System.Collections.Generic;
using Entitas;

public class SkillCardContainerCreatingSystem : GameReactiveSystem
{
	private PlayerSkillFactory _factory;

	public SkillCardContainerCreatingSystem(Contexts contexts, PlayerSkillFactory factory) : base(contexts)
	{
		_factory = factory;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Player);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasPlayer && !entity.hasSkillCardContainer;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var p in _context.GetEntities(GameMatcher.Player))
		{
			var cont = _factory.CreateContainer(p.player.PlayerId);
			p.AddSkillCardContainer(cont);
			if (p.isLocal) cont.gameObject.SetActive(true);
		}
	}
}
