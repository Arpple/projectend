using Entitas;


[Tile]
public class TileHoverActionComponent : IComponent
{
	/// <summary>
	/// action when mouse hover on tile
	/// </summary>
	/// <param name="source">source entity</param>
	/// <param name="target">target entity</param>
	public delegate void TileHoverAction(TileEntity source, TileEntity target);

	public TileEntity Source;
	public TileEntity Target;
	public TileHoverAction HoverAction;

	public void OnHovered()
	{
		HoverAction(Source, Target);
	}
}