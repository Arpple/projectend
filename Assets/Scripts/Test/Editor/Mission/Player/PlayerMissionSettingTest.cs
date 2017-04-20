namespace Test.MissionTest
{
	public class PlayerMissionSettingTest : IndexDataListTest<PlayerMission, PlayerMissionData>
	{
		protected override IndexDataList<PlayerMission, PlayerMissionData> GetDataList()
		{
			return TestHelper.GetGameSetting().MissionSetting.PlayerMission;
		}
	}
}
