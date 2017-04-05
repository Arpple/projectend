using NUnit.Framework;
using Game;

namespace Test.TestAbility
{
	public class TestAbilityRecover : ActiveAbilityTest<GameEntity>
	{
		protected override Ability CreateAbility()
		{
			return new AbilityRecover();
		}

		protected override GameEntity SetupTarget()
		{
			var entity = _contexts.game.CreateEntity();
			entity.AddGameUnitStatus(10, 1, 1, 1, 1);
			entity.AddGameHitpoint(0);
			entity.isGameDead = true;

			return entity;
		}

		[Test]
		public void RecoverAndReviveTarget()
		{
			_activeAbility.OnTargetSelected(_caster, _target);

			Assert.IsFalse(_target.isGameDead);
			Assert.AreEqual(1, _target.gameHitpoint.Value);
		}

		[Test]
		public void PassiveReviveEffect()
		{
			var a = (IReviveAbility)_ability;
			a.OnDead(_target);

			Assert.IsFalse(_target.isGameDead);
			Assert.AreEqual(1, _target.gameHitpoint.Value);
		}
	}
}
