using NUnit.Framework;
using System;
using End.Game;

namespace End.Test.Setting
{
	public class TestCharacterSetting
	{
		private CharacterSetting _setting;

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
