using System.Linq;
using Entitas;

namespace End.Game
{
	public class SetupLocalPlayerSystem : IInitializeSystem
	{
		private readonly Player _localPlayer;

		public SetupLocalPlayerSystem(Contexts contexts, Player localPlayer)
		{
			_localPlayer = localPlayer;
		}

		public void Initialize()
		{
			GameEntity.Player.Where(p => p.player.PlayerObject == _localPlayer)
				.First()
				.isLocalPlayer = true;
		}
	}
}

