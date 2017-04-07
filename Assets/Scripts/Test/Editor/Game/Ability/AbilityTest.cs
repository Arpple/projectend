using NUnit.Framework;
using Game;

namespace Test.TestAbility
{
	[TestFixture]
	public abstract class AbilityTest : ContextsTest
	{
		protected Ability _ability;
		protected UnitEntity _caster;

		[SetUp]
		public void SetupAbility()
		{
			_ability = CreateAbility();
			_caster = SetupCaster();
		}

		protected virtual UnitEntity SetupCaster()
		{
			return _contexts.unit.CreateEntity();
		}

		protected abstract Ability CreateAbility();
	}
}
