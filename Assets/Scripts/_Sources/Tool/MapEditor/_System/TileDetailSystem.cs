using Entitas;
using System.Collections.Generic;

namespace MapEditor {
    public class TileDetailSystem: ReactiveSystem<GameEntity>, IInitializeSystem {
        //readonly GameContext _context;

        public TileDetailSystem(Contexts contexts)
            : base(contexts.game) {
            //this._context = contexts.game;
        }

        protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameTile, GroupEvent.Added);
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameTile;
        }

        public void Initialize() {

        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(var e in entities) {
                e.AddGameTileHoverAction(null,e,HoverTile);
            }
        }

        void HoverTile(GameEntity none,GameEntity b) {
            MapEditorToolkits.ShowHoverTile(b);
        }
    }
}
