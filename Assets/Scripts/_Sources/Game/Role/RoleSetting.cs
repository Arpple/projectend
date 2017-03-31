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
			[Header("Special Role")]
			public bool IsRandom;
			public int RandomCount;
			public int EndCount;
			public int RewardCount;

			public int TotalCount
			{
				get { return OriginCount + InvaderCount + (IsRandom ? RandomCount : EndCount) + RewardCount; }
			}

			public int[] GetRolesCount()
			{
				var endCount = !IsRandom
					? EndCount
					: UnityEngine.Random.Range(0, RandomCount + 1);

				return new int[]
				{
					OriginCount,
					InvaderCount,
					endCount,
					RandomCount - endCount
				};
			}
		}
	}

}
