using Entitas;
using UnityEngine.Events;

namespace Game
{
	[Tile]
	public class TileActionComponent : IComponent
	{
		public UnityAction SelectedAction;

		public void OnSelected()
		{
			SelectedAction();
		}
	}

}
