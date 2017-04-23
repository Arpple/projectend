using System.Collections.Generic;

namespace Network
{
	public interface IPlayerLoader
	{
		List<Player> GetAllPlayer();
		Player GetLocalPlayer();
	}
}