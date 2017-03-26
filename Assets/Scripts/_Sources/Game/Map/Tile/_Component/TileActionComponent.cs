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
		public delegate void TileAction();

		public TileAction SelectedAction;

		public void OnSelected()
		{
			SelectedAction();
		}
	}

}
