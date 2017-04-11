using Entitas;
using Entitas.Blueprints;

public class CharacterBlueprintLoadingSystem : IInitializeSystem
{
	readonly CharacterSetting _setting;
	private readonly UnitContext _context;

	public CharacterBlueprintLoadingSystem(Contexts contexts, CharacterSetting setting)
	{
		_setting = setting;
		_context = contexts.unit;
	}

	protected Blueprint GetBlueprint(UnitEntity entity)
	{
		return _setting.GetCharBlueprint(entity.character.Type);
	}

	protected void LoadUnitData(UnitEntity[] entities)
	{
		foreach (var e in entities)
		{
			e.ApplyBlueprint(GetBlueprint(e));
			e.AddHitpoint(e.unitStatus.HitPoint);
		}
	}

	public void Initialize()
	{
		LoadUnitData(_context.GetEntities(UnitMatcher.Character));
	}
}
