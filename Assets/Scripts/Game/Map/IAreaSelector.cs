using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	public interface IAreaSelector
	{
		/// <summary>
		/// Selects entity in area
		/// </summary>
		/// <param name="center">The center position.</param>
		/// <returns>array of TileAction</returns>
		GameEntity[] GetEntityInArea(MapPositionComponent center);
	}
}