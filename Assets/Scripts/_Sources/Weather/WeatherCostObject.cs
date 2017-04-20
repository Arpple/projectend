using UnityEngine;
using UnityEngine.UI;

public class WeatherCostObject : MonoBehaviour
{
	public Image CostImage;
	public Text CostCountText;

	public void SetResourceData(ResourceCardData data)
	{
		CostImage.sprite = data.MainSprite;
	}

	public void SetCost(int cost)
	{
		CostCountText.text = cost.ToString();
	}
}
