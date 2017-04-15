using System;
using NUnit.Framework;


namespace Test.UnitTest.CharTest
{
	public class CharacterSettingTest
	{
		private CharacterSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().UnitSetting.CharacterSetting;
		}

		[Test]
		public void CheckData_AllEnumHaveData()
		{
			foreach (Character c in Enum.GetValues(typeof(Character)))
			{
				Assert.IsNotNull(_setting.GetCharData(c));
			}
		}

		[Test]
		public void CheckSetting_AllDataTypeDistinct()
		{
			Assert.AreEqual(Enum.GetNames(typeof(Character)).Length, _setting.CharactersData.Count);
		}
	}
}
