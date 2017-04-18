using NUnit.Framework;

namespace Test.MissionTest
{
	public class MissionBossMonolithCompletingSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new MissionBossMonolithCompletingSystem(_contexts));
		}

		[Test]
		public void Execute_BossUnitDead_MissionComplete()
		{
			var p = CreatePlayerEntity(1);
			p.isBossPlayer = true;

			var e = _contexts.unit.CreateEntity();
			e.AddOwner(p);
			e.AddBossUnit(Boss.Monolith);
			e.isDead = true;

			_systems.Execute();

			Assert.IsTrue(_contexts.game.isMainMissionCompleted);
		}
	}
}
