using Entitas;
using Entitas.Unity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas.Blueprints;
using End.Game;

namespace End.MapEditor {
    public class TileDetailSystem: ReactiveSystem<GameEntity>, IInitializeSystem {
        //readonly GameContext _context;

        public TileDetailSystem(Contexts contexts)
            : base(contexts.game) {
            //this._context = contexts.game;
        }

        protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.Tile, GroupEvent.Added);
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasTile;
        }

        public void Initialize() {

        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(var e in entities) {
                e.AddTileHoverAction(null,e,HoverTile);
            }
        }

        void HoverTile(GameEntity none,GameEntity b) {
            MapEditorToolkits.ShowHoverTile(b);
        }
    }
}
