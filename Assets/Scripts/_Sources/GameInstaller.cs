using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas;
using Zenject;

public class GameInstaller : MonoInstaller
{
	public Setting Setting;

	public override void InstallBindings()
	{
		Container.Bind<Setting>().FromInstance(Setting).AsSingle();
	}
}