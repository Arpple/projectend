using UnityEngine;

public abstract class MissionData : EntityData
{
	public string Name;
	[TextArea] public string Description;
	public string TargetDescription;
}