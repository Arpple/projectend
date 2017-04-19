using System;
using NUnit.Framework;

namespace Test.MissionTest
{
	public class MainMissionSettingTest : IndexDataListTest<MainMission, MainMissionData>
	{
		protected override IndexDataList<MainMission, MainMissionData> GetDataList()
		{
			return TestHelper.GetGameSetting().MissionSetting.MainMission;
		}

		[Test]
		public void CheckSetting_AllEnumHaveData()
		{
			foreach(MainMission mission in Enum.GetValues(typeof(MainMission)))
			{
				Assert.IsNotNull(_data.GetData(mission));
			}
		}
	}
}
