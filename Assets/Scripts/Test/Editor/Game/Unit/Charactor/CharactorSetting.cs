using NUnit.Framework;
using UnityEngine;
using System;

namespace End.Test
{
	public class CharacterSetting
	{
		private End.CharacterSetting _setting;

		[SetUp]
		public void Init()
		{
			GameSetting setting = Resources.Load<GameSetting>("Game/Core/Setting/GameSetting");
			_setting = setting.UnitSetting.CharacterSetting;
			Assert.IsNotNull(_setting);
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
