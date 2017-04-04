using NUnit.Framework;
using End.Game;

namespace End.Test.TestAbility
{
	public abstract class ReviveAbilityTest : AbilityTest
	{
		protected IReviveAbility _reviveAbility;
		protected GameEntity _deadEntity;

		[SetUp]
		public void SetupOndeadAbility()
		{
			_reviveAbility = (IReviveAbility)_ability;
			_deadEntity = SetupDeadEntity();
		}

		[Test]
		public void OnDeadApplyAbility()
		{
			_reviveAbility.OnDead(_deadEntity);
		}

		protected virtual GameEntity SetupDeadEntity()
		{
			var entity = _contexts.game.CreateEntity();
			entity.AddHitpoint(0);
			entity.AddUnitStatus(10, 1, 1, 1, 1);

			return entity;
		}
	}
}
