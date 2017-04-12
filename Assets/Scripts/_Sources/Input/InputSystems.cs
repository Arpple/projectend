public class InputSystems : Feature
{
	public InputSystems(Contexts contexts) : base("Control")
	{
		Add(new CameraSystem(contexts));
		Add(new CameraKeyboardSystem(contexts));
	}
}