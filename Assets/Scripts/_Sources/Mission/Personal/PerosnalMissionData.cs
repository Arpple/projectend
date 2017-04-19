using UnityEngine;

[CreateAssetMenu(menuName = "End/Mission/Personal Mission", fileName = "new_mission.asset")]
public class PersonalMissionData : EntityData, IIndexData<PersonalMission>
{
	public PersonalMission Type;
	public string Name;
	[TextArea] public string Description;

	public PersonalMission GetIndex()
	{
		return Type;
	}

	public bool IsIndexEquals(PersonalMission index)
	{
		return Type == index;
	}
}