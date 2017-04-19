using UnityEngine;

namespace Title
{
	[CreateAssetMenu(menuName = "End/Title Setting", fileName = "title_setting.asset")]
	public class TitleSetting : ScriptableObject
	{
		public PlayerIconDataList PlayerIconList;
	}
}
