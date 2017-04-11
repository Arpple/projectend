using NUnit.Framework;

namespace Test.UnitTest
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
			p1.isLocal = true;

			var u1 = _contexts.unit.CreateEntity();
			u1.AddOwner(p1);
			u1.AddCharacter(Character.LastBoss);

			_systems.Execute();

			Assert.IsTrue(u1.isLocal);
		}

		[Test]
		public void RemoveLocalPlayer()
		{
			var p1 = _contexts.game.CreateEntity();
			p1.isLocal = true;
			p1.isLocal = false;

			var u1 = _contexts.unit.CreateEntity();
			u1.isLocal = true;
			u1.AddOwner(p1);
			u1.AddCharacter(Character.LastBoss);

			_systems.Execute();

			Assert.IsFalse(u1.isLocal);
		}
	}
}
