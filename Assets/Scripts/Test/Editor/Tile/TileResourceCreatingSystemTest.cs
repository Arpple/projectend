using NUnit.Framework;

namespace Test.TileTest
{
	public class TileResourceCreatingSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new TileResourceCreatingSystem(_contexts));
		}

		private TileEntity CreateTileEntity(Tile type)
		{
			var entity = _contexts.tile.CreateEntity();
			entity.AddTile(type);
			return entity;
		}

		private void AssertTileHasResouces(TileEntity tile, Resource type)
		{
			Assert.IsTrue(tile.hasResource);
			Assert.AreEqual(type, tile.resource.Type);
		}

		[Test]
		public void Initialize_DeepForestTile_WoodResourceAdded()
		{
			var tile = CreateTileEntity(Tile.DeepForest);
			_systems.Initialize();
			AssertTileHasResouces(tile, Resource.Wood);
		}

		[Test]
		public void Initialize_WaterTile_WaterResourceAdded()
		{
			var tile = CreateTileEntity(Tile.Water);
			_systems.Initialize();
			AssertTileHasResouces(tile, Resource.Water);
		}

		[Test]
		public void Initialize_MountainTile_CoalResourceAdded()
		{
			var tile = CreateTileEntity(Tile.Mountain);
			_systems.Initialize();
			AssertTileHasResouces(tile, Resource.Coal);
		}

		private void NoResourceTileTest(Tile tile)
		{
			var entity = CreateTileEntity(tile);
			_systems.Initialize();
			Assert.IsFalse(entity.hasResource);
		}

		[Test]
		public void Initialize_OtherTile_NoResource()
		{
			NoResourceTileTest(Tile.Desert);
			NoResourceTileTest(Tile.Grass);
			NoResourceTileTest(Tile.SnowMountain);
			NoResourceTileTest(Tile.None);
			NoResourceTileTest(Tile.Snow);
			NoResourceTileTest(Tile.Space);
		}
	}
}
