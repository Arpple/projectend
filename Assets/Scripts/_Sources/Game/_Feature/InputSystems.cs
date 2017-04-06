using Entitas;
namespace Game
{
	public class InputSystems : Feature
	{
		public InputSystems(Contexts contexts) : base("Control")
		{
			Add(new CameraSystem(contexts));
			Add(new CameraKeyboardSystem(contexts));

		}
	}

}
