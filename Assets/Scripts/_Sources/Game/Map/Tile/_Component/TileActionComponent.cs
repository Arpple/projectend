using Entitas;
using UnityEngine.Events;

namespace Game
{
	[Game]
	public class TileActionComponent : IComponent
	{
		public UnityAction SelectedAction;

		public void OnSelected()
		{
			SelectedAction();
		}
	}

}
