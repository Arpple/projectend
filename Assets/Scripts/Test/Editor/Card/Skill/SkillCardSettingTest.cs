using System.Linq;
using NUnit.Framework;

namespace Test.CardTest.SkillTest
{
	public class SkillCardSettingTest
	{
		private SkillCardSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.SkillCardSetting;
		}

		[Test]
		public void CheckSetting_AllDataTypeNotDupplicate()
		{
			var count = _setting.SkillCardsData.Count;
			Assert.AreEqual(count, _setting.SkillCardsData
				.Select(d => d.Type)
				.Distinct()
				.Count()
			);
		}
	}
}
