using Entitas;
using System.Collections.Generic;

namespace MapEditor {
    public class TileDetailSystem : IInitializeSystem
	{
		readonly TileContext _context;

        public TileDetailSystem(Contexts contexts)
		{
			_context = contexts.tile;
        }

        public void Initialize()
		{
			foreach (var e in _context.GetEntities(TileMatcher.Tile))
			{
				e.AddTileHoverAction(() => HoverTile(e));
			}
		}

        void HoverTile(TileEntity tile) {
            MapEditorToolkits.ShowHoverTile(tile);
        }
    }
}
