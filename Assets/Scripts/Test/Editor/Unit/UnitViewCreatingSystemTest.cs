using Entitas.Unity;
using NUnit.Framework;
using UnityEngine;

namespace Test.UnitTest
{
	public class UnitViewCreatingSystemTest : EntityViewCreatingSystemTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new UnitViewCreatingSystem(_contexts, new GameObject()));
		}

		[Test]
		public void Execute_EntityHasSprite_ViewCreatedAndLinked()
		{
			var unit = _contexts.unit.CreateEntity();
			unit.AddSprite(null);
			unit.AddCharacter(Character.LastBoss);

			_systems.Execute();

			Assert.IsTrue(unit.hasView);

			var view = unit.view.GameObject;

			Assert.IsNotNull(view);
			Assert.AreEqual(view.GetEntityLink().entity, unit);
		}
	}
}
