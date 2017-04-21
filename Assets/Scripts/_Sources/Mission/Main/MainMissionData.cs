using UnityEngine;

[CreateAssetMenu(menuName = "End/Mission/Main Mission", fileName = "mainMission.asset")]
public class MainMissionData : MissionData, IIndexData<MainMission>
{
	public MainMission Type;

	public MainMission GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(MainMission index)
	{
		return Type == index;
	}
}
