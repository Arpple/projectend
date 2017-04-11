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

		public TileEntity CreateEntity(TileData data)
		{
			var e = _context.CreateEntity();
			var compFac = new TileComponentFactory(e, data);
			compFac.AddComponents();
			return e;
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