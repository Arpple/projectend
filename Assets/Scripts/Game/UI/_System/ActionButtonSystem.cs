using Entitas;

namespace End.Game.UI
{
	public abstract class ActionButtonSystem : IInitializeSystem
	{
		protected readonly ActionButton _button;
		protected readonly Contexts _contexts;

		public ActionButtonSystem(Contexts contexts, ActionButton button)
		{
			_button = button;
			_contexts = contexts;
		}

		public abstract void Initialize();
	}
}

