using NUnit.Framework;

namespace Test.GameTest.MissionTest
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
			p.player.PlayerObject.MainMissionId = (int)MainMission.BossMonolith;

			_systems.Initialize();

			Assert.AreEqual(MainMission.BossMonolith, p.mainMission.Type);
		}
	}
}
