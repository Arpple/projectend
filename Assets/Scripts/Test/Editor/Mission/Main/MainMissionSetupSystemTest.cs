using NUnit.Framework;

namespace Test.MissionTest
{
	public class MainMissionSetupSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new MainMissionSetupSystem(_contexts));
		}

		[Test]
		public void Initialize_LocalPlayerEntityWithMission_MainMissionEntitySet()
		{
			var p = CreatePlayerEntity(1);
			p.isLocal = true;
			p.player.GetNetworkPlayer().MainMissionId = (int)MainMission.BossMonolith;

			_systems.Initialize();

			Assert.AreEqual(MainMission.BossMonolith, _contexts.game.mainMission.Type);
		}
	}
}
