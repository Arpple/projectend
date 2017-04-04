using UnityEngine;
using NUnit.Framework;
using End.Game;
using System;

namespace End.Test.TestAbility
{
	public class TestAbilityAttack : AbilityTest
	{
		protected override Ability CreateAbility()
		{
			return new AbilityAttack();
		}

		protected override GameEntity SetupCaster()
		{
			var entity = base.SetupCaster();
			entity.AddUnitStatus(1, 2, 1, 1, 1);

			return entity;
		}

		protected override GameEntity SetupTarget()
		{
			var entity = base.SetupTarget();
			entity.AddHitpoint(10);

			return entity;
		}

		[Test]
		public void DealDamageToTarget()
		{
			_ability.OnTargetSelected(_caster, _target);
			Assert.AreEqual(8, _target.hitpoint.Value);
		}
	}
}
