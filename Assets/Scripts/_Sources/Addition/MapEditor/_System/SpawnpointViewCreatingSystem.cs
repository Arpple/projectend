using Entitas;
using UnityEngine;

namespace MapEditor
{
	public class SpawnpointViewCreatingSystem : EntityViewCreatingSystem<TileEntity>
	{
		private GameObject _spawnpointPrefabs;
		private GameObject _bossspawnpointPrefabs;

		public SpawnpointViewCreatingSystem(Contexts contexts, GameObject spawnpointPrefabs, GameObject bossSpawnpointPrefabs) : base(contexts.tile)
		{
			_spawnpointPrefabs = spawnpointPrefabs;
			_bossspawnpointPrefabs = bossSpawnpointPrefabs;
		}

		protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
		{
			return context.CreateCollector(TileMatcher.Spawnpoint);
		}

		protected override bool Filter(TileEntity entity)
		{
			return entity.hasSpawnpoint && entity.hasView;
		}

		protected override void AddViewObject(TileEntity entity, GameObject viewObject)
		{
			entity.AddMapEditorSpawnpointView(viewObject);
		}

		protected override GameObject CreateViewObject(TileEntity entity)
		{
			var prefabs = entity.spawnpoint.index > 0
				? _spawnpointPrefabs
				: _bossspawnpointPrefabs;
			var view = Object.Instantiate(prefabs) as GameObject;
			view.transform.SetParent(entity.view.GameObject.transform, false);
			return view;
		}
	}
}