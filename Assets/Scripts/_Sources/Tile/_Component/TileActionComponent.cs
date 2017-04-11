using Entitas;
using UnityEngine.Events;

[Tile]
public class TileActionComponent : IComponent
{
	public UnityAction SelectedAction;

	public void OnSelected()
	{
		SelectedAction();
	}
}