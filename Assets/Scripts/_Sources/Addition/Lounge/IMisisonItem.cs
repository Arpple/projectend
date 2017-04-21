using UnityEngine.Events;

namespace Lounge
{
	public interface IMissionItem
	{
		void SetMissionData(MissionData data);
		string GetMissionName();
		string GetMissionTarget();
		string GetMissionDescription();
		void SetOnSelectedAction(UnityAction<IMissionItem> action);

		void Focus();
		void UnFocus();
	}
}
