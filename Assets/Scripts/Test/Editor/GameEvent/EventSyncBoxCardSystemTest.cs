using NUnit.Framework;

namespace Test.EventTest
{
	public class EventSyncBoxCardSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new EventSyncBoxCardSystem(_contexts));
		}

		[Test]
		public void Execute_EventSyncBoxCard_SetCardBoxIndex()
		{
			var card = _contexts.card.CreateEntity();
			card.AddInBox(1);

			var e = _contexts.gameEvent.CreateEntity();
			e.AddEventSyncBoxCard(card, 2);

			_systems.Execute();

			Assert.AreEqual(2, card.inBox.Index);
		}
	}
}
