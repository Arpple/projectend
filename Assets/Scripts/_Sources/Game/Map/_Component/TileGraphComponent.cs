using System.Linq;
using Entitas;

namespace Game
{
	[Game]
	public class TileGraphComponent : IComponent
	{
		public GameEntity Up;
		public GameEntity Down;
		public GameEntity Left;
		public GameEntity Right;

		public GameEntity[] GetConnectedTiles()
		{
			return new GameEntity[] { Up, Down, Left, Right }.Where(t => t != null).ToArray();
		}
	}
}
