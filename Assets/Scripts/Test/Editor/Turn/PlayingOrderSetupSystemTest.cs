using NUnit.Framework;


namespace Test.TurnTest
{
	public class PlayingOrderSetupSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new PlayingOrderSetupSystem(_contexts));
		}

		[Test]
		public void Initialize_PlayerEntitiesCreated_PlayingOrderCreatedOrderByPlayerId()
		{
			var p1 = CreatePlayerEntity(1);
			var p2 = CreatePlayerEntity(2);

			_systems.Initialize();
			var order = _contexts.game.playingOrder;

			Assert.IsNotNull(order);
			Assert.AreEqual(2, order.PlayerOrder.Count);
			Assert.AreEqual(p1, order.PlayerOrder[0]);
			Assert.AreEqual(p2, order.PlayerOrder[1]);
		}
	}
}
