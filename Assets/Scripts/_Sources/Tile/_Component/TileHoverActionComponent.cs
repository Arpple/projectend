using Entitas;
using UnityEngine.Events;

[Tile]
public class TileHoverActionComponent : IComponent
{
	public UnityAction TileHoverAction;

	public void OnHovered()
	{
		TileHoverAction();
	}
}