using Title;
using NUnit.Framework;
using UnityEngine;

namespace Test.AdditionTest.TitleTest
{
	public class PlayerIconSettingTest : IndexDataListTest<PlayerIcon, PlayerIconData>
	{
		protected override IndexDataList<PlayerIcon, PlayerIconData> GetDataList()
		{
			return TestHelper.GetTitleSetting().PlayerIconList;
		}

		[Test]
		public void CheckSetting_AllDataCanLoadSpriteFromPath()
		{
			foreach(var d in _data.DataList)
			{
				Assert.IsNotNull(Resources.Load<Sprite>(d.IconPath));
			}
		}
	}
}
