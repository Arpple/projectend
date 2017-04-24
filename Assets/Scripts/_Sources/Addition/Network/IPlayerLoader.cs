using System.Collections.Generic;

namespace Network
{
	public interface IPlayerLoader
	{
		bool IsNetwork();
		List<Player> GetAllPlayer();
		Player GetLocalPlayer();
	}
}