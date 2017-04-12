using NUnit.Framework;

namespace Test.CardTest
{
	public class CardDataLoadingSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new CardDataLoadingSystem(_contexts, TestHelper.GetGameSetting().CardSetting));
		}

		[Test]
		public void Execute_CardEntityAdded_ComponentFromDataLoaded()
		{
			var card = _contexts.card.CreateEntity();
			card.AddCard(Card.Move);

			_systems.Execute();
			Assert.IsTrue(card.hasSprite);
		}
	}
}
