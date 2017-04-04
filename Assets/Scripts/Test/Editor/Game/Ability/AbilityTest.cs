using NUnit.Framework;
using Game;

namespace Test.TestAbility
{
	[TestFixture]
	public abstract class AbilityTest : ContextsTest
	{
		protected Ability _ability;
		protected GameEntity _caster;

		[SetUp]
		public void SetupAbility()
		{
			_ability = CreateAbility();
			_caster = SetupCaster();
		}

		protected virtual GameEntity SetupCaster()
		{
			return _contexts.game.CreateEntity();
		}

		protected abstract Ability CreateAbility();
	}
}
