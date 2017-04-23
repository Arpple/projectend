namespace Network
{
	public class OfflineSceneLoader : SceneLoader
	{
		protected override void OnSetupComplete()
		{
			SetReady();
		}
	}
}