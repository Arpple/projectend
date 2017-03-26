﻿using NUnit.Framework;
using End.Game;

namespace End.Test
{
	public class TestGameSetting
	{
		//private Contexts _contexts;
		private GameSetting _setting;

		[SetUp]
		public void Init()
		{
			//_contexts = TestHelper.CreateContexts();
			_setting = TestHelper.GetGameSetting();
		}

		[Test]
		public void ComponentAssigned()
		{
			Assert.IsNotNull(_setting.MapSetting);
			Assert.IsNotNull(_setting.UnitSetting);
			Assert.IsNotNull(_setting.CardSetting);
		}
	}
}
