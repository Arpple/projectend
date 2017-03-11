#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Test
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