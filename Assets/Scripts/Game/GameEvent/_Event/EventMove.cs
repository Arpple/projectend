using Entitas;
using System.Linq;
using UnityEngine.Assertions;
using System;

namespace End.Game
{
	[GameEvent]
	public class EventMove : GameEventComponent
	{
		public GameEntity MovingEntity;
		public int x;
		public int y;

		public static void Create(GameEntity entity, MapPositionComponent position)
		{
			Assert.IsTrue(entity.hasUnit);
			Assert.IsTrue(entity.hasMapPosition);

			GameEvent.CreateEvent<EventMove>(entity.unit.OwnerPlayer.PlayerId, position.x, position.y);
		}

		public void Decode(int playerId, int x, int y)
		{
			MovingEntity = Contexts.sharedInstance.game.GetEntities(GameMatcher.Character)
				.Where(c => c.unit.OwnerPlayer.PlayerId == playerId)
				.First();

			this.x = x;
			this.y = y;
		}
	}

	public class EventMoveSystem : GameEventSystem
	{
		public EventMoveSystem(Contexts contexts) : base(contexts){}

		protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
		{
			return context.CreateCollector(GameEventMatcher.EventMove, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.hasEventMove;
		}

		protected override void Process(GameEventEntity entity)
		{
			var e = entity.eventMove;

			e.MovingEntity.ReplaceMapPosition(e.x, e.y);
		}
	}
}
