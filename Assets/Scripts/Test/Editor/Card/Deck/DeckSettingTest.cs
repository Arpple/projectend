﻿using NUnit.Framework;
using System;
using System.Linq;


namespace Test.CardTest.DeckTest
{
	public class DeckSettingTest
	{
		private DeckSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.DeckSetting;
		}

		[Test]
		public void CheckSetting_DeckSettingAdded()
		{
			Assert.IsNotNull(_setting.Deck);
		}

		[Test]
		public void CheckSetting_DeckSettingIsNotDupplicate()
		{
			var setCount = _setting.Deck.SettingList.Count;
			Assert.AreEqual(setCount, _setting.Deck.SettingList
				.Select(set => set.Type)
				.Distinct()
				.Count()
			);
		}
	}
}

