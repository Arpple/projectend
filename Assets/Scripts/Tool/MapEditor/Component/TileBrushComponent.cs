using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.CodeGenerator.Api;

namespace End.MapEditor
{
	public enum BrushAction
	{
		Tile,
		Spawnpoint,
	}

	[Game, Unique]
	public class TileBrushComponent : IComponent
	{
		public Tile TileType;
		public BrushAction Action;
		public int SpawnpointIndex;
	}

}
