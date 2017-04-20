using Network;
using NUnit.Framework;

namespace Test.TurnTest
{
	public class RoundLimitSetupSystemTest : ContextsTest
	{
		private Player _player;

		[SetUp]
		public void Init()
		{
			var player = CreatePlayerEntity(1);
			player.isLocal = true;
			_player = player.player.GetNetworkPlayer();
			_systems.Add(new RoundLimitSetupSystem(_contexts));
		}

		[Test]
		public void Initialize_PlayerHaveRoundLimit1_RoundLimitSetTo1()
		{
			_player.RoundLimit = 1;
			_systems.Initialize();

			Assert.IsTrue(_contexts.game.hasRoundLimit);
			Assert.AreEqual(1, _contexts.game.roundLimit.Count);
		}

		[Test]
		public void Initialize_PlayerHaveRoundLimit0_ThrowInvalidRoundException()
		{
			_player.RoundLimit = 0;

			Assert.Throws(typeof(RoundLimitSetupSystem.RoundLimitInvalidException),
				new TestDelegate(InitializeSystem));
		}

		[Test]
		public void Initialize_PlayerHaveRoundLimitMinus1_ThrowInvalidRoundException()
		{
			_player.RoundLimit = -1;

			Assert.Throws(typeof(RoundLimitSetupSystem.RoundLimitInvalidException),
				new TestDelegate(InitializeSystem));
		}

		private void InitializeSystem()
		{
			_systems.Initialize();
		}
	}
}
