using System.Collections.Generic;
using System.Linq;
using Entitas;

public class LocalCharacterStatusSystem : ReactiveSystem<UnitEntity>, IInitializeSystem
{
	private readonly UnitContext _context;
	private readonly PlayerUnitStatusPanel _ui;

	public LocalCharacterStatusSystem(Contexts contexts, PlayerUnitStatusPanel ui) : base(contexts.unit)
	{
		_context = contexts.unit;
		_ui = ui;
	}

	public void Initialize()
	{
		_ui.SetCharacter(_context.GetEntities(UnitMatcher.Character)
			.Where(c => c.owner.Entity.isLocal)
			.First());
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.UnitStatus, GroupEvent.Added);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.hasUnitStatus && entity.owner.Entity.isLocal;
	}

	protected override void Execute(List<UnitEntity> entities)
	{
		foreach (var entity in entities)
		{
			_ui.UpdateUnitStatus(entity.unitStatus);
		}
	}
}