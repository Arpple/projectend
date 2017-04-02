using NUnit.Framework;
using End.Game;

namespace End.Test.System
{
	public class TestLoadAbilitySystem : ContextsTest
	{
		[Test]
		public void AbilityCreate()
		{
			var system = new LoadAbilitySystem(_contexts);

			var e = _contexts.game.CreateEntity();
			e.AddAbility("End.Game.AbilityMove", null);

			system.Execute();

			Assert.IsNotNull(e.ability.Ability);
		}
	}
}

