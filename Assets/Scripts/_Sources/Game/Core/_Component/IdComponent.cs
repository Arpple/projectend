using Entitas;
using Entitas.CodeGeneration.Attributes;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[Game, Tile, Card, Unit]
	public class IdComponent : IComponent
	{
		[EntityIndex]
		public int Id;
	}

}
