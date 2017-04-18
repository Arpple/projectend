using UnityEngine;

namespace Title
{
	[CreateAssetMenu(menuName = "End/PlayerIcon", fileName = "new_icon.asset")]
	public class PlayerIconData : ScriptableObject, IIndexData<PlayerIcon>
	{
		public PlayerIcon Type;
		public string IconPath;

		public PlayerIcon GetIndex()
		{
			return Type;
		}

		public bool IsIndexEquals(PlayerIcon index)
		{
			return Type == index;
		}
	}
}