using System;
using UnityEngine;
using System.Collections.Generic;

namespace End.Game
{
	[Serializable]
	public class RoleSetting
	{
		public List<RoleCountSetting> RoleCount;

		[Serializable]
		public class RoleCountSetting
		{
			public int PlayerCount;
			[Space]
			public int OriginCount;
			public int InvaderCount;
		}
	}

}
