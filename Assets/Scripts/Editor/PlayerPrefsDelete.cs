using UnityEngine;
using UnityEditor;

public class PlayerPrefsDelete
{
	[MenuItem("Edit/Reset PlayerPrefs")]
	public static void ResetPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("PlayerPrefs reseted");
	}
}
