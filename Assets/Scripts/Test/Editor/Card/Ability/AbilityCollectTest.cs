using Entitas;
using NUnit.Framework;

namespace Test.CardTest.AbilityTest
{
	public class AbilityCollectTest : ActiveAbilityTest<TileEntity>
	{
		protected override Ability CreateAbility()
		{
			return new AbilityCollect();
		}

		protected override UnitEntity SetupCaster()
		{
			var unit = base.SetupCaster();
			var p = CreatePlayerEntity(1);
			unit.AddOwner(p);
			return unit;
		}

		protected override TileEntity SetupTarget()
		{
			var entity = _contexts.tile.CreateEntity();
			entity.AddCharge(1);
			entity.AddTileResource(Resource.Water, null);
			return entity;
		}

		[Test]
		public void OnTargetSelected_TargetHaveCharge_TargetChargeMinusByOne()
		{
			_activeAbility.OnTargetSelected(_caster, _target);

			Assert.AreEqual(0, _target.charge.Count);
		}

		[Test]
		public void OnTargetSelected_TargetHaveCharge_ResourceCardCreateForCaster()
		{
			_activeAbility.OnTargetSelected(_caster, _target);

			var cards = _contexts.card.GetEntities(CardMatcher.ResourceCard);
			Assert.AreEqual(1, cards.Length);
			Assert.AreEqual(_caster.owner.Entity, cards[0].owner.Entity);
			Assert.AreEqual(_target.tileResource.Type, cards[0].resourceCard.Type);
		}
	}
}
