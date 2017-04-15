//using System.Collections.Generic;
//using System.Linq;
//using Entitas;

//public class RoleInvaderWinningSystem : ReactiveSystem<UnitEntity>
//{
//	private readonly GameContext _gameContext;
//	private readonly UnitContext _unitContext;

//	public RoleInvaderWinningSystem(Contexts contexts) : base(contexts.unit)
//	{
//		_gameContext = contexts.game;
//		_unitContext = contexts.unit;
//	}

//	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
//	{
//		return context.CreateCollector(UnitMatcher.Dead, GroupEvent.Added);
//	}

//	protected override bool Filter(UnitEntity entity)
//	{
//		return entity.isDead && entity.owner.Entity.role.RoleObject is RoleOrigin;
//	}

//	protected override void Execute(List<UnitEntity> entities)
//	{
//		var origins = _gameContext.GetEntities(GameMatcher.Role)
//			.Where(r => r.role.RoleObject is RoleOrigin);

//		if (!origins.All(i => _unitContext.GetCharacterFromPlayer(i).isDead)) return;

//		foreach (var i in _gameContext.GetEntities(GameMatcher.Role)
//			.Where(r => r.role.RoleObject is RoleInvader))
//		{
//			i.isWinner = true;
//		}
//	}
//}