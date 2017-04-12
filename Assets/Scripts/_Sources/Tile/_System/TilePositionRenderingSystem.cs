using System.Collections.Generic;
using Entitas;
public class TilePositionRenderingSystem : ReactiveSystem<TileEntity>
{

	public TilePositionRenderingSystem(Contexts contexts) : base(contexts.tile)
	{ }

	protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
	{
		return context.CreateCollector(TileMatcher.MapPosition, GroupEvent.Added);
	}

	protected override bool Filter(TileEntity entity)
	{
		return entity.hasMapPosition && entity.hasView;
	}

	protected override void Execute(List<TileEntity> entities)
	{
		foreach (var e in entities)
		{
			var transform = e.view.GameObject.transform;
			transform.position = e.mapPosition.GetWorldPosition();
		}
	}
}