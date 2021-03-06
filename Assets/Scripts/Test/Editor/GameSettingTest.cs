﻿using NUnit.Framework;


namespace Test.GameTest
{
	public class GameSettingTest
	{
		private Setting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting();
		}

		[Test]
		public void ComponentAssigned()
		{
			Assert.IsNotNull(_setting.TileSetting);
			Assert.IsNotNull(_setting.UnitSetting);
			Assert.IsNotNull(_setting.CardSetting);
		}
	}
}
