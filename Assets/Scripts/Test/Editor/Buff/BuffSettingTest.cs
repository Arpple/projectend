using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas;
using NUnit.Framework;

namespace Test.BuffTest
{
	public class BuffSettingTest : IndexDataListTest<Buff, BuffData>
	{
		protected override IndexDataList<Buff, BuffData> GetDataList()
		{
			return TestHelper.GetGameSetting().BuffSetting;
		}

		private BuffSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().BuffSetting;
		}

		[Test]
		public void CheckSetting_AllBuffDurationMoreThanZero()
		{
			foreach(var data in _setting.DataList)
			{
				Assert.IsTrue(data.Duration > 0);
			}
		}

		
	}
}
