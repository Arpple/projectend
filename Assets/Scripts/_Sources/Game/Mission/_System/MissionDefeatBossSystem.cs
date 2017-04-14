//using System.Collections.Generic;
//using Entitas;

//public class MissionBossFightBossDefeatedSystem : ReactiveSystem<UnitEntity>
//{
//	private GameContext _context;

//	public MissionBossFightBossDefeatedSystem(Contexts contexts) : base(contexts.unit)
//	{
//		_context = contexts.game;
//	}

//	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
//	{
//		return context.CreateCollector(UnitMatcher.Dead);
//	}

//	protected override bool Filter(UnitEntity entity)
//	{
//		return entity.isDead && entity.owner.Entity.isBoss;
//	}

//	protected override void Execute(List<UnitEntity> entities)
//	{
//		foreach(var p in _context.GetEntities(GameMatcher.Player))
//		{
//			p.isMainMissionComplete = true;
//		}
//	}
//}
