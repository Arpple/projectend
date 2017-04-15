using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace MapEditor
{
	public class SpawnpointViewDestroySystem : TileReactiveSystem
	{
		public SpawnpointViewDestroySystem(Contexts contexts) : base(contexts)
		{
		}

		protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
		{
			return context.CreateCollector(TileMatcher.Spawnpoint, GroupEvent.Removed);
		}

		protected override bool Filter(TileEntity entity)
		{
			return !entity.hasSpawnpoint && entity.hasMapEditorSpawnpointView;
		}

		protected override void Execute(List<TileEntity> entities)
		{
			foreach(var e in entities)
			{
				var spView = e.mapEditorSpawnpointView.GameObject;
				if(spView.GetComponent<EntityLink>() != null)
					spView.Unlink();
				Object.Destroy(spView);
				e.RemoveMapEditorSpawnpointView();
			}
		}
	}
}
