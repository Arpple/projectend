public partial class TileEntityFactory : EntityFactory<TileEntity, TileData>
{
	public class TileComponentFactory : ComponentFactory<TileEntity, TileData>
	{
		public TileComponentFactory(TileEntity entity, TileData data) : base(entity, data)
		{
		}

		public override void AddComponents()
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