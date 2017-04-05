using System.Collections.Generic;
using Entitas;
using UnityEngine.Assertions;

namespace Game {
    public class TileHoverActionSystem: ReactiveSystem<TileEntity>, ITearDownSystem {
        readonly TileContext _context;

        public TileHoverActionSystem(Contexts contexts)
            : base(contexts.tile) {
            _context = contexts.tile;
        }

        protected override Collector<TileEntity> GetTrigger(IContext<TileEntity> context) {
            return context.CreateCollector(TileMatcher.GameTileAction, GroupEvent.Added);
        }

        protected override bool Filter(TileEntity entity) {
            return entity.hasGameTileAction;
        }

        protected override void Execute(List<TileEntity> entities) {
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
            foreach(var e in _context.GetEntities(TileMatcher.GameTile)) {
                var tileCon = e.gameView.GameObject.GetComponent<TileController>();
                Assert.IsNotNull(tileCon);

               // tileCon.ClickAction = null;
            }
        }
    }

}
