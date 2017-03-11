using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End
{
	/// <summary>
	/// game data holder
	/// </summary>
	public class GameSetting : ScriptableObject
	{
		public MapSetting MapSetting;
		public UnitSetting UnitSetting;
		public DeckSetting DeckSetting;
	}

}
