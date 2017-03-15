using System.Collections.Generic;
using Entitas;
using UnityEngine.Assertions;

namespace End.Game {
    public class TileHoverActionSystem: ReactiveSystem<GameEntity>, ITearDownSystem {
        readonly GameContext _context;

        public TileHoverActionSystem(Contexts contexts)
            : base(contexts.game) {
            _context = contexts.game;
        }

        protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.TileAction, GroupEvent.Added);
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasTileAction;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(var e in entities) {
                Assert.IsTrue(e.hasView);
                Assert.IsTrue(e.hasTile);

                var tileCon = e.view.GameObject.GetComponent<TileController>();
                Assert.IsNotNull(tileCon);
                
                var tileHoverAction = e.tileHoverAction;
                tileCon.MouseEnterAction = () => tileHoverAction.HoverAction(tileHoverAction.Source, tileHoverAction.Target);
            }
        }

        public void TearDown() {
            foreach(var e in _context.GetEntities(GameMatcher.Tile)) {
                var tileCon = e.view.GameObject.GetComponent<TileController>();
                Assert.IsNotNull(tileCon);

                tileCon.ClickAction = null;
            }
        }
    }

}
