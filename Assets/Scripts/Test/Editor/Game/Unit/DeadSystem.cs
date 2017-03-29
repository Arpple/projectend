using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using End.Game;

namespace End.Test
{
	public class TestDeadSystem
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void IsDeadWhenHpDrop()
		{
			var system = new DeadSystem(_contexts);

			var unit = _contexts.game.CreateEntity();
			unit.AddHitpoint(1);

			system.Execute();
			Assert.IsFalse(unit.isDead);

			unit.ReplaceHitpoint(0);
			system.Execute();
			Assert.IsTrue(unit.isDead);
		}
	}

}

