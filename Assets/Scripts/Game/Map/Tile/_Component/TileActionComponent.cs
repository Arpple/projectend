using Entitas;

namespace End.Game
{
	[Game]
	public class TileActionComponent : IComponent
	{
		/// <summary>
		/// action when click on tile
		/// </summary>
		/// <param name="actor">source entity</param>
		/// <param name="target">target entity</param>
		public delegate void TileAction(GameEntity actor, GameEntity target);

		public GameEntity Source;
		public GameEntity Target;
		public TileAction SelectedAction;

		public void OnSelected()
		{
			SelectedAction(Source, Target);
		}
	}

}
