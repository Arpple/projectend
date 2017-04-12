using System;
using NUnit.Framework;


namespace Test.UnitTest
{
	public class TestCharacterSetting
	{
		private UnitSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().UnitSetting;
		}

		[Test]
		public void CheckEnumData()
		{
			foreach (Character c in Enum.GetValues(typeof(Character)))
			{
				Assert.IsNotNull(_setting.GetCharData(c));
			}
		}
	}
}
