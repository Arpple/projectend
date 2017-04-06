using Entitas;
using Entitas.CodeGenerator.Api;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[Game, Tile, Card]
	public class IdComponent : IComponent
	{
		[EntityIndex]
		public int Id;
	}

}
