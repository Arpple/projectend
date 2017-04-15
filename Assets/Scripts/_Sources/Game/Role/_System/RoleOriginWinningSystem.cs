//using System.Collections.Generic;
//using System.Linq;
//using Entitas;

//public class RoleOriginWinningSystem : ReactiveSystem<UnitEntity>
//{
//	private readonly GameContext _gameContext;
//	private readonly UnitContext _unitContext;

//	public RoleOriginWinningSystem(Contexts contexts) : base(contexts.unit)
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
//		return entity.isDead && entity.owner.Entity.role.RoleObject is RoleInvader;
//	}

//	protected override void Execute(List<UnitEntity> entities)
//	{
//		var invaders = _gameContext.GetEntities(GameMatcher.Role)
//			.Where(r => r.role.RoleObject is RoleInvader);

//		if (!invaders.All(i => _unitContext.GetCharacterFromPlayer(i).isDead)) return;

//		foreach (var o in _gameContext.GetEntities(GameMatcher.Role)
//			.Where(r => r.role.RoleObject is RoleOrigin))
//		{
//			o.isWinner = true;
//		}
//	}
//}