using NUnit.Framework;
using UnityEngine;
using System;
using End.Game;

namespace End.Test
{
	public class CardSetting
	{
		private Game.CardSetting _setting;

		[SetUp]
		public void Init()
		{
			GameSetting setting = Resources.Load<GameSetting>("Game/Core/_Setting/GameSetting");
			_setting = setting.DeckSetting.CardSetting;
			Assert.IsNotNull(_setting);
		}

		[Test]
		public void CheckEnumBlueprint()
		{
			foreach (Card c in Enum.GetValues(typeof(Card)))
			{
				Assert.IsNotNull(_setting.GetCardBlueprint(c), "Card blueprint not fonud for " + c.ToString());
			}
		}
	}
}

