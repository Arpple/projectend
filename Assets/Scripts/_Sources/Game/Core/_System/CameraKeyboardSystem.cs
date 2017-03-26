using UnityEngine;
using Entitas;

namespace End.Game
{
	public class CameraKeyboardSystem : IExecuteSystem
	{
		const float SPEED = 0.1f;

		private Camera _camera;

		public CameraKeyboardSystem(Contexts context)
		{
			_camera = Camera.main;
		}

		public void Execute()
		{
			Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
			_camera.transform.Translate(move * SPEED);
		}
	}
}

