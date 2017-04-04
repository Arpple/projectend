using NUnit.Framework;
using End.Game;

namespace End.Test.TestAbility
{
	[TestFixture]
	public abstract class ActiveAbilityTest : AbilityTest
	{
		protected IActiveAbility _activeAbility;
		protected GameEntity _target;

		[SetUp]
		public void SetupActiveAbililty()
		{
			_activeAbility = (IActiveAbility)CreateAbility();
			_target = SetupTarget();
		}

		protected virtual GameEntity SetupTarget()
		{
			return _contexts.game.CreateEntity();
		}

		[Test]
		public void ActivateAbility()
		{
			_activeAbility.OnTargetSelected(_caster, _target);
		}
	}
}
