using NUnit.Framework;
using End.Game;

namespace End.Test.TestAbility
{
	public class TestAbilityRecover : ActiveAbilityTest
	{
		protected override Ability CreateAbility()
		{
			return new AbilityRecover();
		}

		protected override GameEntity SetupTarget()
		{
			var entity = base.SetupTarget();
			entity.AddUnitStatus(10, 1, 1, 1, 1);
			entity.AddHitpoint(0);
			entity.isDead = true;

			return entity;
		}

		[Test]
		public void RecoverAndReviveTarget()
		{
			_activeAbility.OnTargetSelected(_caster, _target);

			Assert.IsFalse(_target.isDead);
			Assert.AreEqual(1, _target.hitpoint.Value);
		}

		[Test]
		public void PassiveReviveEffect()
		{
			var a = (IReviveAbility)_ability;
			a.OnDead(_target);

			Assert.IsFalse(_target.isDead);
			Assert.AreEqual(1, _target.hitpoint.Value);
		}
	}
}
