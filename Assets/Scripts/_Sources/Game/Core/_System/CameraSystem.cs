using UnityEngine;
using Entitas;

namespace Game
{
	public class CameraSystem : IExecuteSystem
	{
		const float DRAG_SPEED = 10;

		private Camera _camera;
		private Vector3 _origin;

		public CameraSystem(Contexts context)
		{
			_camera = Camera.main;
		}

		public void Execute ()
		{
			if(Input.GetMouseButtonDown(1))
			{
				_origin = _camera.ScreenToViewportPoint(Input.mousePosition);
				return;
			}

			if(!Input.GetMouseButton(1)) return;

			Vector3 newPos = _camera.ScreenToViewportPoint(Input.mousePosition);
			Vector3 direction = -1 * (newPos - _origin);
			_origin = newPos;

			_camera.transform.Translate(direction * DRAG_SPEED, Space.World);
		}
	}

}
