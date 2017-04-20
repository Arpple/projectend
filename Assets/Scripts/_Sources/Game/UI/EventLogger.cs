using UnityEngine;
using UnityEngine.UI;

public class EventLogger : MonoBehaviour
{
	public static EventLogger Instance;
	public static void ShowMessge(string msg)
	{
		Instance.ShowMessage(msg);
	}

	public Text LogText;

	private void Awake()
	{
		Instance = this;
	}

	public void ShowMessage(string msg)
	{
		LogText.text = msg;
	}
}