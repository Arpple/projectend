using UnityEngine;
using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestDeadSystem : ContextsTest
	{
		private GameEntity _ownerPlayer;
		private GameEntity _unit;

		[SetUp]
		public void Init()
		{
			_ownerPlayer = _contexts.game.CreateEntity();
			_ownerPlayer.AddPlayer(new GameObject().AddComponent<Player>());

			_unit = _contexts.game.CreateEntity();
			_unit.AddUnit(0, _ownerPlayer);
		}

		[Test]
		public void IsDeadWhenHpDrop()
		{
			var system = new DeadSystem(_contexts);
			_unit.AddHitpoint(1);

			system.Execute();
			Assert.IsFalse(_unit.isDead);

			_unit.ReplaceHitpoint(0);
			system.Execute();
			Assert.IsTrue(_unit.isDead);
		}
	}

}

