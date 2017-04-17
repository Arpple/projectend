using System.Collections.Generic;
using Entitas;

public class SkillCardContainerRenderingSystem : ReactiveSystem<CardEntity>
{
	public SkillCardContainerRenderingSystem(Contexts contexts) : base(contexts.card)
	{
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.SkillCard);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasSkillCard;
	}

	protected override void Execute(List<CardEntity> entities)
	{
		foreach (var e in entities)
		{
			e.owner.Entity.skillCardContainer.ContainerObject.AddCard(e.view.GameObject);
		}
	}
}