using Entitas;
using System.Linq;
using UnityEngine.Assertions;
using System;

namespace End.Game
{
	[GameEvent]
	public class EventDamage : GameEventComponent
	{
		public GameEntity SourceUnit;
		public GameEntity TargetUnit;
		public int damage;

		public static void Create(GameEntity source, GameEntity target, int damage)
		{
			Assert.IsTrue(source.hasUnitStatus);
			Assert.IsTrue(target.hasUnitStatus);

			Assert.IsTrue(target.hasHitpoint);

			GameEvent.CreateEvent<EventDamage>(source.unit.Id, target.unit.Id, damage);
		}

		public void Decode(int sourceId, int targetId, int damage)
		{
			SourceUnit = Contexts.sharedInstance.game.GetEntities(GameMatcher.Unit)
				.Where(u => u.unit.Id == sourceId)
				.First();

			TargetUnit = Contexts.sharedInstance.game.GetEntities(GameMatcher.Unit)
				.Where(u => u.unit.Id == targetId)
				.First();

			this.damage = damage;
		}
	}

	public class EventDamageSystem : GameEventSystem
	{
		public EventDamageSystem(Contexts contexts) : base(contexts){ }

		protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
		{
			return context.CreateCollector(GameEventMatcher.EventDamage, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.hasEventDamage;
		}

		protected override void Process(GameEventEntity entity)
		{
			var e = entity.eventDamage;

			e.TargetUnit.ModifyHitpoint(-e.damage);
		}
	}
}
