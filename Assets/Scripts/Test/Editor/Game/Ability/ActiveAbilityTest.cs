using NUnit.Framework;
using Game;

namespace Test.TestAbility
{
	[TestFixture]
	public abstract class ActiveAbilityTest<TTarget> : AbilityTest where TTarget : Entitas.Entity
	{
		protected ActiveAbility<TTarget> _activeAbility;
		protected TTarget _target;

		[SetUp]
		public void SetupActiveAbililty()
		{
			_activeAbility = (ActiveAbility<TTarget>)CreateAbility();
			_target = SetupTarget();
		}

		protected abstract TTarget SetupTarget();

		[Test]
		public void ActivateAbility()
		{
			_activeAbility.OnTargetSelected(_caster, _target);
		}
	}
}
