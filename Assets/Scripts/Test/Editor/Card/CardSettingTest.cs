using NUnit.Framework;
using UnityEngine;

namespace Test.CardTest
{
	public class CardSettingTest
	{
		private CardSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting;
		}

		[Test]
		public void CheckSetting_CardObjectPrefabsSet()
		{
			Assert.IsNotNull(_setting.CardObjectPrefabs);
			var card = Object.Instantiate(_setting.CardObjectPrefabs) as CardObject;
			Assert.IsNotNull(card);
		}

		[Test]
		public void CheckSetting_CardDataAdded()
		{
			Assert.IsNotNull(_setting.CardsData);
		}
	}
}
