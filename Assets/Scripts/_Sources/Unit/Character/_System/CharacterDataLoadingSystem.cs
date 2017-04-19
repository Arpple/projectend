using Entitas;

public class CharacterDataLoadingSystem : DataLoadingSystem<UnitEntity, CharacterData>
{
	CharacterSetting _setting;

	public CharacterDataLoadingSystem(Contexts contexts, CharacterSetting setting) : base(contexts.unit)
	{
		_setting = setting;
	}

	protected override IEntityFactory<UnitEntity, CharacterData> CreateEntityFactory(IContext<UnitEntity> context)
	{
		return new CharacterEntityFactory(context );
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.Character);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.hasCharacter;
	}

	protected override CharacterData GetData(UnitEntity entity)
	{
		return _setting.GetData(entity.character.Type);
	}

	
}
