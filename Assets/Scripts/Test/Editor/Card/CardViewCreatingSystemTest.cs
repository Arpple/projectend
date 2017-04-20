using NUnit.Framework;

namespace Test.CardTest
{
	public class CardViewCreatingSystemTest : EntityViewCreatingSystemTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new CardViewCreatingSystem(_contexts, TestHelper.GetGameSetting().CardSetting));
		}

		[Test]
		public void Execute_EntityHasSprite_ViewCreated()
		{
			var card = _contexts.card.CreateEntity();
			card.AddCardDescription("card", "", "");
			card.AddSprite(null);

			_systems.Execute();

			Assert.IsTrue(card.hasView);
		}
	}
}
