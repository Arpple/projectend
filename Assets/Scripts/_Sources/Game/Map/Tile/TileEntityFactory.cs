using UnityEngine;
using System.Collections;

namespace Game
{
	public class TileEntityFactory
	{
		private TileContext _context;

		public TileEntityFactory(TileContext context)
		{
			_context = context;
		}

		public TileEntity CreateEntityWithComponents(TileData data)
		{
			var e = _context.CreateEntity();
			AddComponents(e, data);
			return e;
		}

		public TileEntity AddComponents(TileEntity entity, TileData data)
		{
			var compFac = new TileComponentFactory(entity, data);
			compFac.AddComponents();
			return entity;
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
				if(_data.Sprite != null)
				{
					_entity.AddGameSprite(_data.Sprite);
				}
			}

			private void AddMovableComponent()
			{
				_entity.isGameTileMovable = _data.IsWalkableOn;
			}
		}
	}
}