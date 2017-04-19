using System;
using NUnit.Framework;


namespace Test.UnitTest.CharTest
{
	public class CharacterSettingTest : IndexDataListTest<Character, CharacterData>
	{
		private CharacterSetting _setting;

		protected override IndexDataList<Character, CharacterData> GetDataList()
		{
			return TestHelper.GetGameSetting().UnitSetting.CharacterSetting;
		}

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().UnitSetting.CharacterSetting;
		}

		[Test]
		public void CheckSetting_AllEnumHaveData()
		{
			foreach (Character c in Enum.GetValues(typeof(Character)))
			{
				Assert.IsNotNull(_setting.GetData(c));
			}
		}	
	}
}
