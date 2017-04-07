using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Game;
using Game.UI;

namespace Test.Setting
{
	public class TestCardSetting
	{
		private CardSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting;
		}

		[Test]
		public void LoadPrefabs()
		{
			Assert.IsNotNull(_setting.CardObjectPrefabs);
			var card = Object.Instantiate(_setting.CardObjectPrefabs) as CardObject;
			Assert.IsNotNull(card);
		}
	}
}
