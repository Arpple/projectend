using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RoleSystems : Feature
{
	public RoleSystems(Contexts contexts, RoleSetting setting) :base("Role System")
	{
		if (GameController.Instance.IsOffline)
			Add(new RoleSetupSystem(contexts, setting.GetRolesCount(GameController.Instance.Players.Count)));
		else
			Add(new RoleLoadingSystem(contexts));
	}
}