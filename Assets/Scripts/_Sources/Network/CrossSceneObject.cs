using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End
{
	public class CrossSceneObject : MonoBehaviour
	{
		public static CrossSceneObject Instance;

		public void Awake()
		{
			if(Instance != null)
			{
				Destroy(Instance);
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
