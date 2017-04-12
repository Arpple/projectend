using System;
using Entitas;

public partial class TileEntityFactory : EntityFactory<TileEntity, TileData>, IEntityFactory<TileEntity, TileData>
{
	public TileEntityFactory(IContext<TileEntity> context) : base(context)
	{
	}

	protected override ComponentFactory<TileEntity, TileData> CreateComponentFactory(TileEntity entity, TileData data)
	{
		return new TileComponentFactory(entity, data);
	}
}