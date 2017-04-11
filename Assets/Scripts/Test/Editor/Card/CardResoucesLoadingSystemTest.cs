using NUnit.Framework;

namespace Test.CardTest
{
	public class CardResoucesLoadingSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new CardResoucesLoadingSystem(_contexts, TestHelper.GetGameSetting().CardSetting));
		}

		[Test]
		public void Initialize()
		{
			var card = _contexts.card.CreateCard(Card.Move);
			card.AddResource("Test/Editor/Sprite", "");

			_systems.Initialize();

			Assert.IsTrue(card.hasView);
		}

		[Test]
		public void Execute()
		{
			var card = _contexts.card.CreateCard(Card.Move);
			card.AddResource("Test/Editor/Sprite", "");

			_systems.Execute();

			Assert.IsTrue(card.hasView);
		}

		[TearDown]
		public void After()
		{
			_systems.TearDown();
		}
	}
}
