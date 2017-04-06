using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Game.UI
{
	public class TurnNode : MonoBehaviour
	{
		public Image IconImage;

		private UnitEntity _unit;

		public void SetCharacter(UnitEntity unit)
		{
			_unit = unit;

			if(unit.hasGameUnitIcon)
				SetTurnIcon(unit.gameUnitIcon.IconSprite);
		}

		public void SetTurnIcon(Sprite iconSprite)
		{
			IconImage.sprite = iconSprite;
		}

		public void SetAsCurrentTurn()
		{
			//show border or pointer
		}

		public void FocusPlayer()
		{
			var camera = Camera.main;
			Vector3 target = _unit.gameMapPosition.GetWorldPosition();
			Vector3 current = camera.transform.position;

			StartCoroutine(MoveCamera(camera.transform, current, target, 0.1f));
		}

		IEnumerator MoveCamera(Transform camera, Vector3 start, Vector3 end, float time)
		{
			float tick = 0;
			float rate = 1 / time;

			var s = new Vector3(start.x, start.y, camera.position.z);
			var e = new Vector3(end.x, end.y, camera.position.z);

			while (tick < 1)
			{
				tick += Time.deltaTime * rate;
				camera.position = Vector3.Lerp(s, e, tick);
				yield return 0;
			}
		}
	}

}
