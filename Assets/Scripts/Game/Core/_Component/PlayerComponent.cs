using Entitas;

namespace End.Game
{
	[Game]
	public class PlayerComponent : IComponent
	{
		public Player PlayerObject;

		public int PlayerId
		{
			get { return PlayerObject.PlayerId; }
		}
	}

}
