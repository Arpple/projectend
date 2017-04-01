using Entitas;
namespace End.Game
{
	public class ControlSystem : Feature
	{
		public ControlSystem(Contexts contexts) : base("Control")
		{
			Add(new CameraSystem(contexts));
			Add(new CameraKeyboardSystem(contexts));

		}
	}

}
