using MapEditor;
using NUnit.Framework;
using UnityEngine;

namespace Test.AdditionTest.MapEditorTest
{
	public class SpawnpointViewDestroySystemTest : ContextsTest
	{
		TileEntity _spawnpoint;

		[SetUp]
		public void Init()
		{
			_systems.Add(new SpawnpointViewDestroySystem(_contexts));
			_spawnpoint = _contexts.tile.CreateEntity();
			_spawnpoint.AddSpawnpoint(1);
			_spawnpoint.AddView(new GameObject());
			_spawnpoint.AddMapEditorSpawnpointView(new GameObject());
		}

		[Test]
		public void Execute_SpawnpointRemoved_SpawnpointViewRemoved()
		{
			_spawnpoint.RemoveSpawnpoint();
			_systems.Execute();

			Assert.IsFalse(_spawnpoint.hasMapEditorSpawnpointView);
		}
	}
}
