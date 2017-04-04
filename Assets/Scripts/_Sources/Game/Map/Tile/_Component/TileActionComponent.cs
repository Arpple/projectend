using Entitas;

namespace Game
{
	[Game]
	public class TileActionComponent : IComponent
	{
		/// <summary>
		/// action when click on tile
		/// </summary>
		/// <param name="actor">source entity</param>
		/// <param name="target">target entity</param>
		public delegate void TileAction(GameEntity tile);

		public TileAction SelectedAction;

		public void OnSelected(GameEntity tile)
		{
			SelectedAction(tile);
		}
	}

}
