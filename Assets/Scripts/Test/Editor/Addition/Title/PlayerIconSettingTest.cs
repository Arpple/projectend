namespace Test.AdditionTest.TitleTest
{
	public class PlayerIconSettingTest : IndexDataListTest<PlayerIcon, PlayerIconData>
	{
		protected override IndexDataList<PlayerIcon, PlayerIconData> GetDataList()
		{
			return TestHelper.GetGameSetting().PlayerIconSetting;
		}
	}
}
