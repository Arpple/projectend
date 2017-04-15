using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Test.UnitTest.BossTest
{
	public class BossGameObjectRenameSystemTest : ContextsTest
	{
		Boss _testBossType;

		[SetUp]
		public void Init()
		{
			_systems.Add(new BossGameobjectRenameSystem(_contexts));
			_testBossType = Boss.Monolith;
		}

		[Test]
		public void Execute_BossEntityWithView_ViewObjectRenameToBossType()
		{
			var e = _contexts.unit.CreateEntity();
			e.AddBossUnit(_testBossType);
			e.AddView(new UnityEngine.GameObject());

			_systems.Execute();

			Assert.AreEqual(_testBossType.ToString(), e.view.GameObject.name);
		}
	}
}
