using Entitas;

public partial class CharacterEntityFactory : UnitEntityFactory, IEntityFactory<UnitEntity, CharacterData>
{
	public CharacterEntityFactory(IContext<UnitEntity> context) : base(context)
	{
	}

	public void AddComponents(UnitEntity entity, CharacterData data)
	{
		var compFact = new CharacterComponentFactory(entity, data);
		compFact.AddComponents();
	}

	public UnitEntity CreateEntityWithComponents(CharacterData data)
	{
		var entity = _context.CreateEntity();
		AddComponents(entity, data);
		return entity;
	}
}