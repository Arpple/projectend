using System.Linq;
using Entitas;

namespace Game
{
	[Tile]
	public class TileGraphComponent : IComponent
	{
		public TileEntity Up;
		public TileEntity Down;
		public TileEntity Left;
		public TileEntity Right;

		public TileEntity[] GetConnectedTiles()
		{
			return new[] { Up, Down, Left, Right }.Where(t => t != null).ToArray();
		}
	}
}
