using System;
using NUnit.Framework;


namespace Test.TileTest
{
	public class TestTileSetting
	{
		private TileSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().MapSetting.TileSetting;
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

