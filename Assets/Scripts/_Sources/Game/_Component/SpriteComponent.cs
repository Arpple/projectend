using Entitas;
using UnityEngine;

[Tile, Unit]
public class SpriteComponent : IComponent
{
	public Sprite Sprite;
}