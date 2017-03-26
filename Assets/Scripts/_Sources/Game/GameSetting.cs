using UnityEngine;

namespace End.Game
{
	/// <summary>
	/// game data holder
	/// </summary>
	public class GameSetting : ScriptableObject
	{
		public MapSetting MapSetting;
		public UnitSetting UnitSetting;
		public CardSetting CardSetting;
	}

}
