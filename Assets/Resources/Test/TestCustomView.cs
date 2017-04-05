#if UNITY_EDITOR

using UnityEngine;

namespace Game.Test
{
	public class TestCustomView : MonoBehaviour, IEntityCustomView<GameEntity>
	{
		public GameObject CreateView(GameEntity entity, Sprite sprite)
		{
			gameObject.name = "CustomName";
			return gameObject;
		}
	}
}

#endif