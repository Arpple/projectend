﻿using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace End.Test
{
	public class TransformExtension
	{
		[Test]
		public void EditorTest()
		{
			var gameObject = new GameObject();
			gameObject.transform.SetParent("Path/To");

			var parent1 = gameObject.transform.parent;
			Assert.AreEqual("To", parent1.name);
			Assert.AreEqual("Path", parent1.parent.name);
		}
	}

}