using UnityEngine;
using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestDeadSystem : ContextsTest
	{
		private GameEntity _ownerPlayer;
		private UnitEntity _unit;

		[SetUp]
		public void Init()
		{
			_ownerPlayer = _contexts.game.CreateEntity();
			_ownerPlayer.AddGamePlayer(new GameObject().AddComponent<Player>());

			_unit = _contexts.unit.CreateEntity();
			_unit.AddGameOwner(_ownerPlayer);
		}

		[Test]
		public void IsDeadWhenHpDrop()
		{
			var system = new DeadSystem(_contexts);
			_unit.AddGameHitpoint(1);

			system.Execute();
			Assert.IsFalse(_unit.isGameDead);

			_unit.ReplaceGameHitpoint(0);
			system.Execute();
			Assert.IsTrue(_unit.isGameDead);
		}
	}

}

