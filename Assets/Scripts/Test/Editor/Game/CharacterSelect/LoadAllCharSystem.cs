using Entitas;
using NUnit.Framework;

namespace End.Test
{
	public class LoadAllCharSytem
	{
		//private Contexts _contexts;
		private Game.GameSetting _setting;

		[SetUp]
		public void Init()
		{
			//_contexts = TestHelper.CreateContexts();
			_setting = TestHelper.GetGameSetting();
		}

		[Test]
		public void ComponentAssigned()
		{
			Assert.IsNotNull(_setting.MapSetting);
			Assert.IsNotNull(_setting.UnitSetting);
			Assert.IsNotNull(_setting.DeckSetting);
		}
	}
}
