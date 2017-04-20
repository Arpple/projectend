using NUnit.Framework;

namespace Test.MissionTest
{
	public class PlayerMissionSetupSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new PlayerMissionSetupSystem(_contexts));
		}

		[Test]
		public void Initialize_PlayerWithMissionId_MissionComponentAdded()
		{
			var p = CreatePlayerEntity(1);
			p.player.GetNetworkPlayer().PlayerMissionId = (int)PlayerMission.Hunter;

			_systems.Initialize();

			Assert.AreEqual(PlayerMission.Hunter, p.playerMission.MisisonType);
		}
	}
}
