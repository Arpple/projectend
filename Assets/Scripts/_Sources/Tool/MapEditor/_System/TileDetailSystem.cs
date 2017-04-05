﻿using Entitas;
using System.Collections.Generic;

namespace MapEditor {
    public class TileDetailSystem: ReactiveSystem<TileEntity>, IInitializeSystem {
        //readonly GameContext _context;

        public TileDetailSystem(Contexts contexts)
            : base(contexts.tile) {
            //this._context = contexts.game;
        }

        protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context) {
            return context.CreateCollector(TileMatcher.GameTile, GroupEvent.Added);
        }

        protected override bool Filter(TileEntity entity) {
            return entity.hasGameTile;
        }

        public void Initialize() {

        }

        protected override void Execute(List<TileEntity> entities) {
            foreach(var e in entities) {
                e.AddGameTileHoverAction(null,e,HoverTile);
            }
        }

        void HoverTile(TileEntity none,TileEntity b) {
            MapEditorToolkits.ShowHoverTile(b);
        }
    }
}
