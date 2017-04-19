namespace Test.MissionTest
{
	public class PersonalMissionSettingTest : IndexDataListTest<PersonalMission, PersonalMissionData>
	{
		protected override IndexDataList<PersonalMission, PersonalMissionData> GetDataList()
		{
			return TestHelper.GetGameSetting().MissionSetting.PersonalMission;
		}
	}
}
