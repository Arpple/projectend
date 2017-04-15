using NUnit.Framework;

namespace Test.UnitTest.BossTest
{
	public class BossDataLoadingSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new BossDataLoadingSystem(_contexts, TestHelper.GetGameSetting().UnitSetting.BossSetting));
		}

		[Test]
		public void Execute_BossEntityAdded_ComponentFromDataLoaded()
		{
			var boss = _contexts.unit.CreateEntity();
			boss.AddBossUnit(Boss.Monolith);

			_systems.Execute();
			Assert.IsTrue(boss.hasSprite);
		}
	}
}
