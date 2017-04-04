using System.Linq;
using NUnit.Framework;
using Game;

namespace Test.Setting
{
	public class TestRoleSetting
	{
		private RoleSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().RoleSetting;
		}

		[Test]
		public void RoleCountValid()
		{
			Assert.IsTrue(_setting.RoleCount.Count > 0);

			//player count for each setting is distinct
			Assert.AreEqual(
				_setting.RoleCount.Count, 
				_setting.RoleCount.Select(rc => rc.PlayerCount).Distinct().Count()
			);

			foreach(var rc in _setting.RoleCount)
			{
				Assert.AreEqual(rc.PlayerCount, rc.Sum(), "Role Count Setting Invalid for P:" + rc.PlayerCount);
			}
		}
	}

}
