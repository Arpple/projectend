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
			AddResource();
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

		private void AddResource()
		{
			if(_data.Resource != Resource.None)
			{
				_entity.AddTileResource(_data.Resource, _data.EmptyResourceSprite);
				if(_entity.hasSprite)
				{
					_entity.tileResource.SetOriginalSprite(_entity.sprite.Sprite);
				}
			}
		}
	}
}