using UnityEngine;

[CreateAssetMenu(menuName = "End/Mission/Player Mission", fileName = "new_mission.asset")]
public class PlayerMissionData : MissionData, IIndexData<PlayerMission>
{
	public PlayerMission Type;

	[Header("Target")]
	public bool RandomPlayer;
	public int Constant;

	public PlayerMission GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(PlayerMission index)
	{
		return Type == index;
	}
}