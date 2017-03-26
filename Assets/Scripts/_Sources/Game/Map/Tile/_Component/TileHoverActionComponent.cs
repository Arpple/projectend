using Entitas;


namespace End.Game {

    [Game]
    public class TileHoverActionComponent : IComponent{
        /// <summary>
		/// action when mouse hover on tile
		/// </summary>
		/// <param name="source">source entity</param>
		/// <param name="target">target entity</param>
		public delegate void TileHoverAction(GameEntity source, GameEntity target);

        public GameEntity Source;
        public GameEntity Target;
        public TileHoverAction HoverAction;

        public void OnHovered() {
            HoverAction(Source, Target);
        }
    }
}
