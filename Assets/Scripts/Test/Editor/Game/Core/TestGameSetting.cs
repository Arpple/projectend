using NUnit.Framework;
using Game;

namespace Test.Setting
{
	public class TestGameSetting
	{
		private GameSetting _setting;

		[SetUp]
		public void Init()
		{
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
