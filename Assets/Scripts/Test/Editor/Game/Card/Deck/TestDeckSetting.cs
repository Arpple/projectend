﻿using NUnit.Framework;
using System;
using System.Linq;
using Game;

namespace Test.Setting
{
	public class TestDeckSetting
	{
		private DeckSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.DeckSetting;

			Assert.IsNotNull(_setting.CardBlueprints);
			Assert.IsNotNull(_setting.Deck);
		}

		[Test]
		public void CheckEnumBlueprint()
		{
			//UnityEngine.Debug.Log(_setting.CardBlueprints.Card_Attack());
			//UnityEngine.Debug.Log(_setting.CardBlueprints.Card_Move());
			//UnityEngine.Debug.Log(_setting.CardBlueprints.Card_Potion());
			foreach (Card c in Enum.GetValues(typeof(Card)))
			{
				Assert.IsNotNull(_setting.GetCardBlueprint(c), "Card blueprint not fonud for " + c.ToString());
			}
		}

		[Test]
		public void CheckDeckData()
		{
			var setList = _setting.Deck.SettingList;

			//no dupplicate setting for each type
			Assert.AreEqual(setList.Count, setList.Select(s => s.Type).Distinct().Count());

			Assert.AreEqual(Enum.GetNames(typeof(Card)).Length, setList.Count);
		}
	}
}

