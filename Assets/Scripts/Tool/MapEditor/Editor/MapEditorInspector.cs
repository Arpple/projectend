using UnityEditor;
using UnityEngine;

namespace End.MapEditor
{
	[CustomEditor(typeof(MapEditorController))]
	public class MapEditorInspector : Editor
	{
		public override void OnInspectorGUI ()
		{
			DrawDefaultInspector();

			MapEditorController mapEditor = (MapEditorController)target;
		}
	}

}
