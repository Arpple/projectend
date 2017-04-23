using UI;
using UnityEngine;

public class BuffObject : MonoBehaviour
{
	public Icon Icon;

	public void SetIconImage(Sprite sprite)
	{
		Icon.SetImage(sprite);
	}
}