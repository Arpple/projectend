using Network;
using NUnit.Framework;
using UnityEngine;

namespace Test.UnitTest
{
	public class DeadSystemTest : ContextsTest
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

			_systems.Add(new DeadSystem(_contexts));
		}

		[Test]
		public void Execute_HpMoreThanZero_IsNotDead()
		{
			_unit.AddHitpoint(1);
			_systems.Execute();
			Assert.IsFalse(_unit.isDead);
		}

		[Test]
		public void Execute_HpDropIsZero_IsDead()
		{
			_unit.AddHitpoint(0);
			_systems.Execute();
			Assert.IsTrue(_unit.isDead);
		}
	}

}

