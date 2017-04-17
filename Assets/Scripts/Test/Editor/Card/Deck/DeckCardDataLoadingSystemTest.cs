using NUnit.Framework;

namespace Test.CardTest.DeckTest
{
	public class DeckCardDataLoadingSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new DeckCardDataLoadingSystem(_contexts, TestHelper.GetGameSetting().CardSetting.DeckSetting));
		}

		[Test]
		public void Execute_CardEntityAdded_ComponentFromDataLoaded()
		{
			var card = _contexts.card.CreateEntity();
			card.AddDeckCard(DeckCard.Move);

			_systems.Execute();
			Assert.IsTrue(card.hasSprite);
			Assert.IsTrue(card.hasAbility);
		}
	}
}
