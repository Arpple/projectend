using System;
using Entitas;

public partial class TileEntityFactory : EntityFactory<TileEntity, TileData>
{
	public TileEntityFactory(IContext<TileEntity> context) : base(context)
	{
	}

	public override TileEntity CreateEntityWithComponents(TileData data)
	{
		var e = _context.CreateEntity();
		AddComponents(e, data);
		return e;
	}

	protected override ComponentFactory<TileEntity, TileData> CreateComponentFactory(TileEntity entity, TileData data)
	{
		return new TileComponentFactory(entity, data);
	}
}