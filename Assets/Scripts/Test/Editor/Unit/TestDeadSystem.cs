using Network;
using NUnit.Framework;
using UnityEngine;

namespace Test.UnitTest
{
	public class TestDeadSystem : ContextsTest
	{
		private GameEntity _ownerPlayer;
		private UnitEntity _unit;

		[SetUp]
		public void Init()
		{
			_ownerPlayer = _contexts.game.CreateEntity();
			_ownerPlayer.AddPlayer(new GameObject().AddComponent<Player>());

			_unit = _contexts.unit.CreateEntity();
			_unit.AddOwner(_ownerPlayer);
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

