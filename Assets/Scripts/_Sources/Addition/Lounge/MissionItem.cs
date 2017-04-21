using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Lounge
{
	public class MissionItem : MonoBehaviour
	{
		public Button Button;
		public UnityAction<MissionItem> OnSelectedAction;

		public Text MissionNameText;

		public Color FocusColor = new Color(1f, 227f / 255f, 0f, 1f);
		public Color NonFocusColor = new Color(69f / 255f, 69f / 255f, 0f, 1f);

		private MissionData _data;

		private void Start()
		{
			Button.onClick.AddListener(OnSelected);
		}

		public void SetMissionData(MissionData data)
		{
			_data = data;
			MissionNameText.text = data.Name;
		}

		public string GetMissionDescription()
		{
			return _data.Description;
		}

		public string GetMissionName()
		{
			return _data.Name;
		}

		public void SetOnSelectedAction(UnityAction<MissionItem> action)
		{
			OnSelectedAction = action;
		}

		private void OnSelected()
		{
			if (OnSelectedAction != null) OnSelectedAction(this);
		}

		public string GetMissionTarget()
		{
			return _data.TargetDescription;
		}

		public void UnFocus()
		{

		}

		public void Focus()
		{

		}
	}
}
