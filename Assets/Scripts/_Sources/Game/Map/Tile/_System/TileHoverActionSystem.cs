using System.Collections.Generic;
using Entitas;
using UnityEngine.Assertions;

namespace Game {
    public class TileHoverActionSystem: ReactiveSystem<GameEntity>, ITearDownSystem {
        readonly GameContext _context;

        public TileHoverActionSystem(Contexts contexts)
            : base(contexts.game) {
            _context = contexts.game;
        }

        protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.GameTileAction, GroupEvent.Added);
        }

        protected override bool Filter(GameEntity entity) {
            return entity.hasGameTileAction;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach(var e in entities) {
                Assert.IsTrue(e.hasGameView);
                Assert.IsTrue(e.hasGameTile);

                var tileCon = e.gameView.GameObject.GetComponent<TileController>();
                Assert.IsNotNull(tileCon);
                
                var tileHoverAction = e.gameTileHoverAction;
                tileCon.MouseEnterAction = () => tileHoverAction.HoverAction(tileHoverAction.Source, tileHoverAction.Target);
            }
        }

        public void TearDown() {
            foreach(var e in _context.GetEntities(GameMatcher.GameTile)) {
                var tileCon = e.gameView.GameObject.GetComponent<TileController>();
                Assert.IsNotNull(tileCon);

               // tileCon.ClickAction = null;
            }
        }
    }

}
