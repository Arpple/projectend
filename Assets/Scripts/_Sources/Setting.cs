using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// game data holder
/// </summary>
[CreateAssetMenu(menuName = "End/Setting/Main Setting", fileName = "new_setting.asset")]
public class Setting : ScriptableObject
{
	public TileSetting TileSetting;

	[Space(15)]
	public UnitSetting UnitSetting;

	[Space(15)]
	public CardSetting CardSetting;

	[Space(15)]
	public MissionSetting MissionSetting;

	[Space(15)]
	public WeatherSetting WeatherSetting;

	[Space(15)]
	public PlayerIconSetting PlayerIconSetting;

	public void OnEnable()
	{
		Assert.IsNotNull(TileSetting);
		Assert.IsNotNull(UnitSetting);
		Assert.IsNotNull(CardSetting);
		Assert.IsNotNull(WeatherSetting);
		Assert.IsNotNull(PlayerIconSetting);
	}
}