using NUnit.Framework;

namespace Test.CardTest.AbilityTest
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
			entity.AddMapPosition(0, 0);

			return entity;
		}

		protected override TileEntity SetupTarget()
		{
			var entity = _contexts.tile.CreateEntity();
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
