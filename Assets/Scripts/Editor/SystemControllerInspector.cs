using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SystemController))]
public class SystemControllerInspector : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		SystemController syscon = (SystemController)target;

		if(Application.isPlaying)
		{
			if (GUILayout.Button("End Game"))
			{
				var e = Contexts.sharedInstance.gameEvent.CreateEntity();
				e.isEventEndGame = true;
			}
		}
	}
}