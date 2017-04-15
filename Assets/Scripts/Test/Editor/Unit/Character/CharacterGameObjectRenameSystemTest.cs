using NUnit.Framework;
using UnityEngine;

namespace Test.UnitTest.CharTest
{
	public class CharacterGameObjectRenameSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new CharacterGameObjectRenameSystem(_contexts));
		}

		[Test]
		public void Execute_CharacterEntityViewCreated_GameObjectRenamedToCharacterType()
		{
			var e = _contexts.unit.CreateEntity();
			e.AddCharacter(Character.None);
			e.AddView(new GameObject());

			_systems.Execute();

			Assert.AreEqual("None", e.view.GameObject.name);
		}
	}
}
