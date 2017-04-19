using System;
using NUnit.Framework;


namespace Test.TileTest
{
	public class TileSettingTest : IndexDataListTest<Tile, TileData>
	{
		private TileSetting _setting;

		protected override IndexDataList<Tile, TileData> GetDataList()
		{
			return TestHelper.GetGameSetting().TileSetting;
		}

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
				Assert.IsNotNull(_setting.GetData(t));
			}
		}

		[Test]
		public void CheckSetting_HaveResourceChargeWeigth()
		{
			Assert.IsNotNull(_setting.TileResourceChargeWeigth);
			Assert.IsTrue(_setting.TileResourceChargeWeigth.Count > 0);
		}

		[Test]
		public void CheckSetting_TileWithResourceHaveEmptySResourceSprite()
		{
			foreach(var data in _setting.DataList)
			{
				if(data.Resource != Resource.None)
				{
					Assert.IsTrue(data.EmptyResourceSprite != null);
				}
			}
		}
	}
}

