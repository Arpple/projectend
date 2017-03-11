#if UNITY_EDITOR

using UnityEngine;

namespace End.Game.Test
{
	public class TestCustomView : MonoBehaviour, ICustomView
	{
		public GameObject CreateView(GameEntity entity, Sprite sprite)
		{
			gameObject.name = "CustomName";
			return gameObject;
		}
	}
}

#endif