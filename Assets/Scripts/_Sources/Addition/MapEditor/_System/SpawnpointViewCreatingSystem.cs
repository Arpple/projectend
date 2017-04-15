using Entitas;
using UnityEngine;

namespace MapEditor
{
	public class SpawnpointViewCreatingSystem : EntityViewCreatingSystem<TileEntity>
	{
		private GameObject _spawnpointPrefabs;

		public SpawnpointViewCreatingSystem(Contexts contexts, GameObject spawnpointPrefabs) : base(contexts.tile)
		{
			_spawnpointPrefabs = spawnpointPrefabs;
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
			var view = Object.Instantiate(_spawnpointPrefabs) as GameObject;
			view.transform.SetParent(entity.view.GameObject.transform, false);
			return view;
		}
	}
}