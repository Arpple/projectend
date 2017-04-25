using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public static CameraController Instance;

	public static void Focus(UnitEntity unit)
	{
		Instance.FocusUnit(unit);
	}

	private Camera _camera;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		_camera = Camera.main;
	}

	public void FocusUnit(UnitEntity unit)
	{
		Vector3 target = unit.mapPosition.GetWorldPosition();
		Vector3 current = _camera.transform.position;

		StartCoroutine(MoveCamera(_camera.transform, current, target, 0.1f));
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