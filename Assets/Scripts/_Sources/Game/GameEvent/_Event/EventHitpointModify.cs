using Entitas;
using System.Linq;
using UnityEngine.Assertions;
using UnityEngine;

namespace End.Game
{
	public enum HitPointModifyType
	{
		Damage,
		FatalDamage,
		Recovery,
	}

	[GameEvent]
	public class EventHitpointModify : GameEventComponent
	{
		public GameEntity SourceUnit;
		public GameEntity TargetUnit;
		public int Value;
		public HitPointModifyType Type;

		public static void Create(GameEntity source, GameEntity target, int value, HitPointModifyType type)
		{
			Assert.IsTrue(target.hasUnitStatus);
			Assert.IsTrue(target.hasHitpoint);

			GameEvent.CreateEvent<EventHitpointModify>(source.unit.Id, target.unit.Id, value, (int)type);
		}

		public void Decode(int sourceId, int targetId, int value, int type)
		{
			SourceUnit = Contexts.sharedInstance.game.GetEntities(GameMatcher.Unit)
				.Where(u => u.unit.Id == sourceId)
				.First();

			TargetUnit = Contexts.sharedInstance.game.GetEntities(GameMatcher.Unit)
				.Where(u => u.unit.Id == targetId)
				.First();

			Value = value;
			Type = (HitPointModifyType)type;
		}
	}

	public class EventHitpointModifySystem : GameEventSystem
	{
		public EventHitpointModifySystem(Contexts contexts) : base(contexts){ }

		protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
		{
			return context.CreateCollector(GameEventMatcher.EventHitpointModify, GroupEvent.Added);
		}

		protected override bool Filter(GameEventEntity entity)
		{
			return entity.hasEventHitpointModify;
		}

		protected override void Process(GameEventEntity entity)
		{
			var e = entity.eventHitpointModify;

			var newHp = e.TargetUnit.hitpoint.HitPoint + (e.Type != HitPointModifyType.Recovery ? -1 : 1 * e.Value);
			e.TargetUnit.ReplaceHitpoint(Mathf.Clamp(newHp, e.Type == HitPointModifyType.FatalDamage ? 0 : 1, e.TargetUnit.unitStatus.HitPoint));
		}
	}
}
