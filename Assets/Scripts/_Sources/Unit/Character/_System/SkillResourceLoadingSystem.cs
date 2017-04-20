using System.Collections.Generic;
using Entitas;

public class SkillResourceLoadingSystem : UnitReactiveSystem
{
	private CardContext _cardContext;

	public SkillResourceLoadingSystem(Contexts contexts) : base(contexts)
	{
		_cardContext = contexts.card;
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.CharacterSkillsResource);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.hasCharacterSkillsResource;
	}

	protected override void Execute(List<UnitEntity> entities)
	{
		foreach(var e in entities)
		{
			foreach(var skill in e.characterSkillsResource.Skills)
			{
				var card = _cardContext.CreateEntity();
				card.AddSkillCard(skill);
				card.AddOwner(e.owner.Entity);
			}
		}
	}
}