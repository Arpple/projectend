using Entitas;
using System.Collections.Generic;

namespace MapEditor {
    public class TileDetailSystem : IInitializeSystem
	{
		readonly TileContext _context;
		readonly MapEditorToolkits _toolKit;

        public TileDetailSystem(Contexts contexts, MapEditorToolkits toolKit)
		{
			_context = contexts.tile;
			_toolKit = toolKit;
        }

        public void Initialize()
		{
			foreach (var e in _context.GetEntities(TileMatcher.Tile))
			{
				e.AddTileHoverAction(() => _toolKit.ShowTileDetail(e));
			}
		}
    }
}
