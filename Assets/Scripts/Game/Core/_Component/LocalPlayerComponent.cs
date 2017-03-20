using Entitas;
using Entitas.CodeGenerator.Api;

namespace End.Game
{
	[Game, Unique]
	public class LocalPlayerComponent : IComponent
	{
		public Player PlayerObject;

		public int PlayerId
		{
			get { return PlayerObject.PlayerId; }
		}
	}

}
