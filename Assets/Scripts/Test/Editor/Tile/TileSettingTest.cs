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
		public void CheckSetting_GameMapAdded()
		{
			Assert.IsNotNull(_setting.GameMap);
		}

		[Test]
		public void CheckSetting_TileControllerPrefabsAdded()
		{
			Assert.IsNotNull(_setting.TileControllerPrefabs);
		}

		[Test]
		public void CheckSetting_AllTileEnumHaveData()
		{
			foreach(Tile t in Enum.GetValues(typeof(Tile)))
			{
				Assert.IsNotNull(_setting.GetTileData(t));
			}
		}

		[Test]
		public void CheckSetting_AllTileDataTypeDistinct()
		{
			Assert.AreEqual(Enum.GetNames(typeof(Tile)).Length, _setting.TileDatas.Count);
		}

		[Test]
		public void CheckSetting_HaveResourceChargeWeigth()
		{
			Assert.IsNotNull(_setting.TileResourceChargeWeigth);
			Assert.IsTrue(_setting.TileResourceChargeWeigth.Count > 0);
		}
	}
}

