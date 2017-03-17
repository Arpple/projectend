using NUnit.Framework;
using UnityEngine;
using System;
using End.Game;

namespace End.Test
{
	public class CharacterSetting
	{
		private Game.CharacterSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().UnitSetting.CharacterSetting;
		}

		[Test]
		public void CheckEnumBlueprint()
		{
			foreach (Character c in Enum.GetValues(typeof(Character)))
			{
				Assert.IsNotNull(_setting.GetCharBlueprint(c), "Character blueprint not fonud for " + c.ToString());
			}
		}
	}

}
