using Entitas;

public class CharacterGameObjectRenameSystem : GameObjectRenameSystem<UnitEntity>
{
	public CharacterGameObjectRenameSystem(Contexts contexts) : base(contexts.unit)
	{
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.View);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.hasView && entity.hasCharacter;
	}

	protected override ViewComponent GetViewComponent(UnitEntity entity)
	{
		return entity.view;
	}

	protected override string GetNewName(UnitEntity entity)
	{
		return entity.character.Type.ToString();
	}
}

