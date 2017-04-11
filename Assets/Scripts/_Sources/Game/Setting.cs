using UnityEngine;

/// <summary>
/// game data holder
/// </summary>
[CreateAssetMenu(menuName = "End/Setting", fileName = "new_setting.asset")]
public class Setting : ScriptableObject
{
	public MapSetting MapSetting;

	[Space(15)]
	public UnitSetting UnitSetting;

	[Space(15)]
	public CardSetting CardSetting;

	[Space(15)]
	public RoleSetting RoleSetting;
}