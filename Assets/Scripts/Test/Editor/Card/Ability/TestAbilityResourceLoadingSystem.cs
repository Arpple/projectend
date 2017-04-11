using NUnit.Framework;


namespace Test.CardTest.AbilityTest
{
	public class TestAbilityResourceLoadingSystem : ContextsTest
	{
		[Test]
		public void LoadResources()
		{
			var system = new AbilityResourceLoadingSystem(_contexts);

			var e = _contexts.card.CreateEntity();
			e.AddAbilityResources("AbilityMove");

			system.Execute();
			system.Cleanup();

			Assert.IsNotNull(e.ability.Ability);
			Assert.IsFalse(e.hasAbilityResources);
		}
	}
}

