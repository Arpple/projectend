using System.Collections.Generic;
using Entitas;

public class LocalSkillCardContainerRenderingSystem : ReactiveSystem<GameEntity>
{
	public LocalSkillCardContainerRenderingSystem(Contexts contexts) : base(contexts.game)
	{
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Local, GroupEvent.AddedOrRemoved);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasSkillCardContainer;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			e.skillCardContainer.ContainerObject.gameObject.SetActive(e.isLocal);
		}
	}
}
