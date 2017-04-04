using NUnit.Framework;
using End.Game;

namespace End.Test.TestAbility
{
	public class TestAbilityRecover : ReviveAbilityTest
	{
		protected override Ability CreateAbility()
		{
			return new AbilityRecover();
		}

		protected override GameEntity SetupDeadEntity()
		{
			var entity = base.SetupDeadEntity();
			entity.isDead = true;

			return entity;
		}

		[Test]
		public void RecoverDeadUnitHp()
		{
			_reviveAbility.OnDead(_deadEntity);

			Assert.IsFalse(_deadEntity.isDead);
			Assert.AreEqual(1, _deadEntity.hitpoint.Value);
		}
	}
}
