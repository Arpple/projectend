using NUnit.Framework;
using System;
using Game;

namespace Test.Setting
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

