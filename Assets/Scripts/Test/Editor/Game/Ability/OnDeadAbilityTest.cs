using NUnit.Framework;
using End.Game;

namespace End.Test.TestAbility
{
	public abstract class OnDeadAbilityTest : AbilityTest
	{
		protected IOnDeadAbility _onDeadAbility;
		protected GameEntity _deadEntity;

		[SetUp]
		public void SetupOndeadAbility()
		{
			_onDeadAbility = (IOnDeadAbility)_ability;
			_deadEntity = SetupDeadEntity();
		}

		[Test]
		public void OnDeadApplyAbility()
		{
			_onDeadAbility.OnDead(_deadEntity);
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
