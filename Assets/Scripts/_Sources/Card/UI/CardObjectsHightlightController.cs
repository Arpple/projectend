using UnityEngine;

public class CardObjectsHightlightController : MonoBehaviour
{
	public static CardObjectsHightlightController Instance;
	public static Color CurrentColor;

	public Color MinColor;
	public Color MaxColor;

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		CurrentColor = Color.Lerp
		(
			MinColor
			, MaxColor
			, Mathf.PingPong(Time.time, 1f)
		);
	}
}
