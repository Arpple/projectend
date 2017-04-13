using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Test.CardTest.AbilityTest
{
	public class AbilityCollectTest : ActiveAbilityTest<TileEntity>
	{
		protected override Ability CreateAbility()
		{
			return new AbilityCollect();
		}

		protected override TileEntity SetupTarget()
		{
			var entity = _contexts.tile.CreateEntity();
			entity.AddCharge(1);
			return entity;
		}

		public void OnTargetSelected_TargetHaveCharge_TargetChargeMinusByOne()
		{
			_activeAbility.OnTargetSelected(_caster, _target);
			Assert.AreEqual(0, _target.charge.Count);
		}
	}
}
