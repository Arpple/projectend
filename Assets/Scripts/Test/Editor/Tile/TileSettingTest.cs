using System;
using NUnit.Framework;


namespace Test.TileTest
{
	public class TileSettingTest
	{
		private TileSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().TileSetting;
		}

		[Test]
		public void CheckEnumData()
		{
			foreach(Tile t in Enum.GetValues(typeof(Tile)))
			{
				Assert.IsNotNull(_setting.GetTileData(t), "Tile blueprint not fonud for " + t.ToString());
			}
		}
	}
}

