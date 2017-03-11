using NUnit.Framework;
using UnityEngine;
using System;
using End.Game;

namespace End.Test
{
	public class TileSetting
	{
		private Game.TileSetting _setting;

		[SetUp]
		public void Init()
		{
			GameSetting setting = Resources.Load<GameSetting>("Game/Core/_Setting/GameSetting");
			_setting = setting.MapSetting.TileSetting;
			Assert.IsNotNull(_setting);
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

