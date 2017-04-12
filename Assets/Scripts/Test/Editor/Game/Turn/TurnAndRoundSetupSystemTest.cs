using NUnit.Framework;


namespace Test.GameTest.TurnTest
{
	public class TurnAndRoundSetupSystemTest : ContextsTest
	{
		[Test]
		public void Initialize_TurnAndRoundAndRoundIndexEntityNotCreated_EntitiesCreated()
		{
			_systems.Add(new TurnAndRoundSetupSystem(_contexts));
			_systems.Initialize();

			Assert.AreEqual(1, _contexts.game.round.Count);
			Assert.AreEqual(0, _contexts.game.roundIndex.Index);
			Assert.AreEqual(1, _contexts.game.turn.Count);
		}
	}
}
