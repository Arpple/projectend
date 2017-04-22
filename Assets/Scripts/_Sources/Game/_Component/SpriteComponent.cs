using Entitas;
using UnityEngine;

[Tile, Unit, Card, Buff]
public class SpriteComponent : IComponent
{
	public Sprite Sprite;
}