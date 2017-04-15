using System;
using NUnit.Framework;

namespace Test.UnitTest.BossTest
{
	public class BossSettingTest
	{
		private BossSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().UnitSetting.BossSetting;
		}

		[Test]
		public void CheckData_AllEnumHaveData()
		{
			foreach (Boss b in Enum.GetValues(typeof(Boss)))
			{
				Assert.IsNotNull(_setting.GetBossData(b));
			}
		}

		[Test]
		public void CheckSetting_AllDataTypeDistinct()
		{
			Assert.AreEqual(Enum.GetNames(typeof(Boss)).Length, _setting.BossData.Count);
		}
	}
}
