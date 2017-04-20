using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnNode : MonoBehaviour
{
	public Image IconImage;
	public GameObject CurrentTurnIndicator;

	private UnitEntity _unit;

	public void SetCharacter(UnitEntity unit)
	{
		_unit = unit;

		if (unit.hasUnitIcon)
			SetTurnIcon(unit.unitIcon.IconSprite);
	}

	public void SetTurnIcon(Sprite iconSprite)
	{
		IconImage.sprite = iconSprite;
	}

	public void SetAsCurrentTurn()
	{
		CurrentTurnIndicator.gameObject.SetActive(true);
        this.GetComponent<Animator>().Play("CrownSpin");
	}

	public void RemoveCurrentTurn()
	{
		CurrentTurnIndicator.gameObject.SetActive(false);
	}

	public void FocusPlayer()
	{
		var camera = Camera.main;
		Vector3 target = _unit.mapPosition.GetWorldPosition();
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