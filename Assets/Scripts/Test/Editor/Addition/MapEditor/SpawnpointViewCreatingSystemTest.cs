using MapEditor;
using NUnit.Framework;
using UnityEngine;

namespace Test.AdditionTest.MapEditorTest
{
	public class SpawnpointViewCreatingSystemTest : ContextsTest
	{
		TileEntity _spawnpoint;

		[SetUp]
		public void Init()
		{
			_systems.Add(new SpawnpointViewCreatingSystem(_contexts, new GameObject()));
			_spawnpoint = _contexts.tile.CreateEntity();
			_spawnpoint.AddSpawnpoint(1);
			_spawnpoint.AddView(new GameObject());
		}

		[Test]
		public void Execute_SpawnpointEntity_ViewComponentCreatedAndSpawnpointViewSetParentAsTileView()
		{
			_systems.Execute();

			Assert.IsTrue(_spawnpoint.hasMapEditorSpawnpointView);
			Assert.AreEqual(_spawnpoint.view.GameObject.transform, _spawnpoint.mapEditorSpawnpointView.GameObject.transform.parent);
		}
	}
}
