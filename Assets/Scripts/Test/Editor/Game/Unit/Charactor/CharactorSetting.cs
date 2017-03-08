using NUnit.Framework;
using UnityEngine;
using System;

namespace End.Test
{
	public class CharactorSetting
	{
		private End.CharactorSetting _setting;

		[SetUp]
		public void Init()
		{
			GameSetting setting = Resources.Load<GameSetting>("Game/Core/Setting/GameSetting");
			_setting = setting.UnitSetting.CharactorSetting;
			Assert.IsNotNull(_setting);
		}

		[Test]
		public void CheckEnumBlueprint()
		{
			foreach (Charactor c in Enum.GetValues(typeof(Charactor)))
			{
				Assert.IsNotNull(_setting.GetCharBlueprint(c), "Charactor blueprint not fonud for " + c.ToString());
			}
		}
	}

}
