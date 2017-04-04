using NUnit.Framework;
using End.Game;

namespace End.Test.TestAbility
{
	[TestFixture]
	public abstract class AbilityTest : ContextsTest
	{
		protected Ability _ability;
		protected GameEntity _caster;
		protected GameEntity _target;

		[SetUp]
		public void SetupAbility()
		{
			_ability = CreateAbility();
			_caster = SetupCaster();
			_target = SetupTarget();
		}

		protected abstract Ability CreateAbility();

		protected virtual GameEntity SetupCaster()
		{
			return _contexts.game.CreateEntity();
		}

		protected virtual GameEntity SetupTarget()
		{
			return _contexts.game.CreateEntity();
		}

		[Test]
		public void ApplyAbility()
		{
			_ability.OnTargetSelected(_caster, _target);
			Assert.Pass();
		}
	}
}
