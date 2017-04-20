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
		public void Initialize_PlayerMissionId0AndTarget0_Mission0FromEnumAdded()
		{
			var p = CreatePlayerEntity(1);
			p.player.GetNetworkPlayer().PlayerMissionId = 0;

			_systems.Initialize();

			Assert.AreEqual((PlayerMission)0, p.playerMission.MisisonType);
		}

		[Test]
		public void Initialize_PlayerMissionId0AndTarget1_MissionAndTargetAdded()
		{
			var p = CreatePlayerEntity(1);
			var player = p.player.GetNetworkPlayer();
			player.PlayerMissionId = (int)PlayerMission.Hunter;
			player.PlayerMissionTarget = 1;

			_systems.Initialize();

			Assert.AreEqual((PlayerMission)0, p.playerMission.MisisonType);
			Assert.AreEqual(p, p.playerMissionTarget.TargetEntity);
		}
	}
}
