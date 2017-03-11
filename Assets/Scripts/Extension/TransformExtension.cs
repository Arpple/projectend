using UnityEngine;
using System;

public static class TransformExtension
{
	/// <summary>
	/// move gameobject to parent by name. or create new parent if not found
	/// </summary>
	/// <param name="gameObject"></param>
	/// <param name="parentName"></param>
	/// <param name="createParentCallback"></param>
	public static void SetParent(this Transform transform, string parentName)
	{
		var parent = GameObject.Find(parentName);
		if (parent == null)
		{
			var currentPath = "";
			GameObject currentObject = null;
			foreach(var path in parentName.Split('/'))
			{
				currentPath += "/" + path;
				var obj = GameObject.Find(currentPath);
				if(obj == null)
				{
					obj = new GameObject(path);
					if(currentObject != null)
					{
						obj.transform.SetParent(currentObject.transform, false);
					}
				}
				currentObject = obj;
			}
			parent = currentObject;
		}
		if (parent != null)
		{
			transform.SetParent(parent.transform, false);
		}
	}
}
