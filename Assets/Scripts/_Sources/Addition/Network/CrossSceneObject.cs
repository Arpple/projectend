using UnityEngine;

namespace Network
{
	public class CrossSceneObject : MonoBehaviour
	{
		public static CrossSceneObject Instance;

		public void Awake()
		{
			if (Instance != null)
			{
				Destroy(Instance.gameObject);
			}

			Instance = this;
			DontDestroyOnLoad(gameObject);
		}

		public static void AddObject(GameObject obj)
		{
			obj.transform.SetParent(Instance.transform, false);
		}
	}
}