using Entitas;

public class TileDataLoadingSystem : DataLoadingSystem<TileEntity, TileData>
{
	private TileSetting _setting;

	public TileDataLoadingSystem(Contexts contexts, TileSetting setting) : base(contexts.tile)
	{
		_setting = setting;
	}

	protected override EntityFactory<TileEntity, TileData> CreateEntityFactory(IContext<TileEntity> context)
	{
		return new TileEntityFactory(context);
	}

	protected override bool Filter(TileEntity entity)
	{
		return entity.hasTile;
	}

	protected override TileData GetData(TileEntity entity)
	{
		return _setting.GetTileData(entity.tile.Type);
	}

	protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context)
	{
		return context.CreateCollector(TileMatcher.Tile);
	}
}
