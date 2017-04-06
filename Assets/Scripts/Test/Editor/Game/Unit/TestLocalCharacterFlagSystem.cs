using UnityEngine;
using UnityEditor;
using Game;
using NUnit.Framework;

namespace Test.System
{
	public class TestLocalCharacterFlagSystem : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new LocalCharacterFlagSystem(_contexts));
		}

		[Test]
		public void SetLocalPlayer()
		{
			var p1 = _contexts.game.CreateEntity();
			p1.isGameLocal = true;

			var u1 = _contexts.unit.CreateEntity();
			u1.AddGameOwner(p1);
			u1.AddGameCharacter(Character.LastBoss);

			_systems.Execute();

			Assert.IsTrue(u1.isGameLocal);
		}

		[Test]
		public void RemoveLocalPlayer()
		{
			var p1 = _contexts.game.CreateEntity();
			p1.isGameLocal = true;
			p1.isGameLocal = false;

			var u1 = _contexts.unit.CreateEntity();
			u1.isGameLocal = true;
			u1.AddGameOwner(p1);
			u1.AddGameCharacter(Character.LastBoss);

			_systems.Execute();

			Assert.IsFalse(u1.isGameLocal);
		}
	}
}
