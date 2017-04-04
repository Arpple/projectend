using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Game.UI
{
	public class HpBar : MonoBehaviour
	{
		public Image CurrentValueBarImage;
		public Text ValueText;

		private int _maxValue;
		private int _current;

		public void SetMaxValue(int x)
		{
			if (x == _maxValue) return;

			UpdateValueText(_current, x);
			UpdateValueBarLength(_current ,x);

			_maxValue = x;
		}

		public void UpdateHp(int x)
		{
			if (x == _current) return;

			UpdateValueText(x, _maxValue);
			UpdateValueBarLength(x, _maxValue);

			_current = x;
		}

		private void UpdateValueText(int current, int max)
		{
			ValueText.text = current + "/" + max;
		}

		private void UpdateValueBarLength(int current, int max)
		{
			var scale = max > 0
				? ((float)current) / max
				: 0;

			CurrentValueBarImage.transform.localScale = new Vector3(scale, 1, 0);
		}
	}

}
