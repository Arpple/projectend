using UnityEngine;
using NUnit.Framework;
using Game;
using System;

namespace Test.TestAbility
{
	public class TestAbilityMove : ActiveAbilityTest<TileEntity>
	{
		protected override Ability CreateAbility()
		{
			return new AbilityMove();
		}

		protected override UnitEntity SetupCaster()
		{
			var entity = base.SetupCaster();
			entity.AddGameMapPosition(0, 0);

			return entity;
		}

		protected override TileEntity SetupTarget()
		{
			var entity = _contexts.tile.CreateEntity();
			entity.AddGameMapPosition(1, 1);

			return entity;
		}

		[Test]
		public void MoveToTargetPosition()
		{
			_activeAbility.OnTargetSelected(_caster, _target);
			Assert.IsTrue(_target.gameMapPosition.Equals(_caster.gameMapPosition));
		}
	}
}
