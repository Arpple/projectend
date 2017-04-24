using UnityEngine;

namespace Network
{
	public class LocalData : MonoBehaviour
	{
		public string PlayerName;
		public PlayerIcon PlayerIcon;
		public int PlayerId;

		private void Start()
		{
			CrossSceneObject.AddObject(gameObject);
		}
	}
}
