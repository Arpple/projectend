using UnityEngine;

namespace Network
{
	public class LocalData : MonoBehaviour
	{
		[Header("Title")]
		public string PlayerName;
		public PlayerIcon PlayerIcon;

		private void Start()
		{
			CrossSceneObject.AddObject(gameObject);
		}
	}
}
