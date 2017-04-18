using Title;

namespace Test.AdditionTest.TitleTest
{
	public class PlayerIconSettingTest : IndexDataListTest<PlayerIcon, PlayerIconData>
	{
		protected override IndexDataList<PlayerIcon, PlayerIconData> GetDataList()
		{
			return TestHelper.GetTitleSetting().PlayerIconList;
		}
	}
}
