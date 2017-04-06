using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestLoadAbilitySystem : ContextsTest
	{
		[Test]
		public void AbilityCreate()
		{
			var system = new LoadAbilitySystem(_contexts);

			var e = _contexts.card.CreateEntity();
			e.AddGameAbility("Game.AbilityMove", null);

			system.Execute();

			Assert.IsNotNull(e.gameAbility.Ability);
		}
	}
}

