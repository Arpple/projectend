using Entitas;

public class TileEntityFactory : EntityFactory<TileEntity, TileData>
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

	public override void AddComponents(TileEntity entity, TileData data)
	{
		var compFac = new TileComponentFactory(entity, data);
		compFac.AddComponents();
	}

	internal class TileComponentFactory
	{
		private TileEntity _entity;
		private TileData _data;

		public TileComponentFactory(TileEntity entity, TileData data)
		{
			_entity = entity;
			_data = data;
		}

		public void AddComponents()
		{
			AddSprite();
			AddMovableComponent();
		}

		private void AddSprite()
		{
			if (_data.Sprite != null)
			{
				_entity.AddSprite(_data.Sprite);
			}
		}

		private void AddMovableComponent()
		{
			_entity.isTileMovable = _data.IsWalkableOn;
		}
	}
}