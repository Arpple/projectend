using Network;

namespace Result
{
	public class NetworkResultController : ResultController
	{
		protected override void Start()
		{
			NetworkController.Instance.Stop();
			base.Start();
		}

		protected override void SetupPlayers()
		{
			foreach(var player in NetworkController.Instance.AllPlayers)
			{
				AddPlayer(player);
				player.transform.SetParent(PlayerParent, false);
			}

			SetLocalPlayer(NetworkController.Instance.LocalPlayer);
		}
	}
}