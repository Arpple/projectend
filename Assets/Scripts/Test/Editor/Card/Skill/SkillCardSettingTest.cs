namespace Test.CardTest.SkillTest
{
	public class SkillCardSettingTest : IndexDataListTest<SkillCard, SkillCardData>
	{
		protected override IndexDataList<SkillCard, SkillCardData> GetDataList()
		{
			return TestHelper.GetGameSetting().CardSetting.SkillCardSetting;
		}
	}
}
