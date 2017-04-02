using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace End.Game.UI
{
	public class TurnNode : MonoBehaviour
	{
		public Image IconImage;

		public void SetTurnIcon(Sprite iconSprite)
		{
			IconImage.sprite = iconSprite;
		}

		public void SetAsCurrentTurn()
		{
			//show border or pointer
		}
	}

}
