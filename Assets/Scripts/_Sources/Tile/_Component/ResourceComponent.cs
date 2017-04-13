using Entitas;
using UnityEngine;

[Tile]
public class TileResourceComponent : IComponent
{
	public Resource Type;
	public Sprite EmptySprite;

	private Sprite _originalSprite;

	public void SetOriginalSprite(Sprite sprite)
	{
		_originalSprite = sprite;
	}

	public Sprite GetOriginalSprite()
	{
		return _originalSprite;
	}
}
