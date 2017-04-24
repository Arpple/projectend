using Network;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	public Setting Setting;
	public LocalData LocalDataPrefabs;

	public override void InstallBindings()
	{
		Container.Bind<Setting>().FromInstance(Setting).AsSingle();
		Container.Bind<LocalData>().FromInstance(Instantiate(LocalDataPrefabs)as LocalData).AsSingle();
	}
}