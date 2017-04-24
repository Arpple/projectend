namespace Network
{
	public class OfflineSceneLoader : SceneLoader
	{
		private int _playerId;

		protected override void Awake()
		{
			base.Awake();
			_playerId = 1;
		}

		protected override void OnSetupComplete()
		{
			SetReady();
		}

		protected override void SetupPlayer(Player player)
		{
			base.SetupPlayer(player);
			player.PlayerId = _playerId;
			_playerId++;
		}
	}
}