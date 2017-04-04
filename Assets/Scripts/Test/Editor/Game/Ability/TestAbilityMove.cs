using UnityEngine;
using NUnit.Framework;
using Game;
using System;

namespace Test.TestAbility
{
	public class TestAbilityMove : ActiveAbilityTest
	{
		protected override Ability CreateAbility()
		{
			return new AbilityMove();
		}

		protected override GameEntity SetupCaster()
		{
			var entity = base.SetupCaster();
			entity.AddMapPosition(0, 0);

			return entity;
		}

		protected override GameEntity SetupTarget()
		{
			var entity = base.SetupTarget();
			entity.AddMapPosition(1, 1);

			return entity;
		}

		[Test]
		public void MoveToTargetPosition()
		{
			_activeAbility.OnTargetSelected(_caster, _target);
			Assert.IsTrue(_target.mapPosition.Equals(_caster.mapPosition));
		}
	}
}
