using NUnit.Framework;

namespace Test.CardTest.AbilityTest
{
	public class TestAbilityAttack : ActiveAbilityTest<UnitEntity>
	{
		protected override Ability CreateAbility()
		{
			return new AbilityAttack();
		}

		protected override UnitEntity SetupCaster()
		{
			var entity = base.SetupCaster();
			entity.AddUnitStatus(1, 2, 1, 1, 1);

			return entity;
		}

		protected override UnitEntity SetupTarget()
		{
			var entity = _contexts.unit.CreateEntity();
			entity.AddHitpoint(10);

			return entity;
		}

		[Test]
		public void OnTargetSelected_DamageComponentAddedToTarget()
		{
			_activeAbility.OnTargetSelected(_caster, _target);
			Assert.IsTrue(_target.hasAbilityAttack);
		}
	}
}
