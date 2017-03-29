using UnityEngine;

namespace End.Game
{
	/// <summary>
	/// game data holder
	/// </summary>
	public class GameSetting : ScriptableObject
	{
		public MapSetting MapSetting;

		[Space(15)]
		public UnitSetting UnitSetting;

		[Space(15)]
		public CardSetting CardSetting;

		[Space(15)]
		public RoleSetting RoleSetting;
	}

}
