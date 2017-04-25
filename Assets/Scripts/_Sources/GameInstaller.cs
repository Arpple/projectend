using Network;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	public Setting Setting;
	public LocalData LocalDataPrefabs;
	public CrossSceneObject CrossSceneObject;
	public LoadingScreen LoadingScreen;

	public override void InstallBindings()
	{
		Container.Bind<Setting>().FromInstance(Setting).AsSingle();
		Container.Bind<LocalData>().FromInstance(Instantiate(LocalDataPrefabs)as LocalData).AsSingle();
		Container.Bind<CrossSceneObject>().FromInstance(Instantiate(CrossSceneObject) as CrossSceneObject).AsSingle();
		Container.Bind<LoadingScreen>().FromInstance(Instantiate(LoadingScreen) as LoadingScreen).AsSingle();
		Container.Bind<Contexts>().FromMethod(CreateContexts).AsSingle();
		Container.Bind<Camera>().FromInstance(Camera.main).AsTransient();
	}

	Contexts CreateContexts(InjectContext context)
	{
		return Contexts.sharedInstance;
	}
}