﻿using NUnit.Framework;
using System;
using End.Game;

namespace End.Test.Setting
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
		public void CheckEnumBlueprint()
		{
			foreach(Tile t in Enum.GetValues(typeof(Tile)))
			{
				Assert.IsNotNull(_setting.GetTileBlueprint(t), "Tile blueprint not fonud for " + t.ToString());
			}
		}
	}
}
