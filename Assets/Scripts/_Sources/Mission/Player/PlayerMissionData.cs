using UnityEngine;

[CreateAssetMenu(menuName = "End/Mission/Player Mission", fileName = "new_mission.asset")]
public class PlayerMissionData : EntityData, IIndexData<PlayerMission>
{
	public PlayerMission Type;
	public string Name;
	[TextArea] public string Description;

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