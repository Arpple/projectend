using System.Linq;
using Network;

namespace Result
{
	public class OfflineResultController : ResultController
	{
		protected override void SetupPlayers()
		{
			var players = PlayerParent.GetComponentsInChildren<Player>(true);

			foreach (var p in players)
			{
				AddPlayer(p);
			}

			SetLocalPlayer(players.First());
		}
	}
}
