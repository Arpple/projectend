﻿public class BuffSystems : Feature
{
	public BuffSystems(Contexts contexts, Setting setting) : base("Buff")
	{
		Add(new BuffDataLoadingSystem(contexts, setting.BuffSetting));
		Add(new BuffExpireSystem(contexts));
	}
}