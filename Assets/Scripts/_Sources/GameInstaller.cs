using Network;
using Zenject;

public class GameInstaller : MonoInstaller
{
	public Setting Setting;
	public LocalData LocalDataPrefabs;

	public override void InstallBindings()
	{
		Container.Bind<Setting>().FromInstance(Setting).AsSingle();
		Container.Bind<LocalData>().FromComponentInNewPrefab(LocalDataPrefabs).AsSingle();
	}
}