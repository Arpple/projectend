using Entitas;
using System.Linq;
using UnityEngine.Assertions;
using System;

namespace End.Game
{
	[GameEvent]
	public class EventMoveUnit : GameEventComponent
	{
		public GameEntity MovingEntity;
		public int x;
		public int y;

		public static void Create(GameEntity entity, MapPositionComponent position)
		{
			Assert.IsTrue(entity.hasUnit);
			Assert.IsTrue(entity.hasMapPosition);

			GameEvent.CreateEvent<EventMoveUnit>(entity.unit.OwnerEntity.player.PlayerId, position.x, position.y);
		}

		public void Decode(int playerId, int x, int y)
		{
			MovingEntity = Contexts.sharedInstance.game.GetEntities(GameMatcher.Character)
				.Where(c => c.unit.OwnerEntity.player.PlayerId == playerId)
				.First();

			this.x = x;
			this.y = y;
		}
	}

	public class EventMoveUnitSystem : GameEventSystem
	{
		public EventMoveUnitSystem(Contexts contexts) : base(contexts){}

		protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
		{
			return context.CreateCollector(GameEventMatcher.EventMoveUnit, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.hasEventMoveUnit;
		}

		protected override void Process(GameEventEntity entity)
		{
			var e = entity.eventMoveUnit;

			e.MovingEntity.ReplaceMapPosition(e.x, e.y);
		}
	}
}
