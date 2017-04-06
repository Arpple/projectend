using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestAbilityResourceLoadingSystem : ContextsTest
	{
		[Test]
		public void LoadResources()
		{
			var system = new AbilityResourceLoadingSystem(_contexts);

			var e = _contexts.card.CreateEntity();
			e.AddGameAbilityResources("Game.AbilityMove");

			system.Execute();
			system.Cleanup();

			Assert.IsNotNull(e.gameAbility.Ability);
			Assert.IsFalse(e.hasGameAbilityResources);
		}
	}
}

