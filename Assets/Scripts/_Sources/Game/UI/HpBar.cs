using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace End.Game.UI
{
	public class HpBar : MonoBehaviour
	{
		public Image CurrentValueBarImage;
		public Text ValueText;

		private int _maxValue;

		public void SetMaxValue(int x)
		{
			_maxValue = x;
		}

		public void SetCurrentValue(int x)
		{
			ValueText.text = x + "/" + _maxValue;
			UpdateValueBar(x);
		}

		public void UpdateValueBar(int current)
		{
			var scale = _maxValue > 0
				? ((float)current) / _maxValue
				: 0;

			CurrentValueBarImage.transform.localScale = new Vector3(scale, 1, 0);
		}
	}

}
