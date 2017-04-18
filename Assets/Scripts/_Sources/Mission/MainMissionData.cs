using UnityEngine;

[CreateAssetMenu(menuName = "End/Main Mission", fileName = "mainMission.asset")]
public class MainMissionData : EntityData, IIndexData<MainMission>
{
	public MainMission Type;
	public string Name;
	[TextArea] public string Description;

	public MainMission GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(MainMission index)
	{
		return Type == index;
	}
}
