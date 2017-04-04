using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
	[Serializable]
	public class RoleSetting
	{
		public List<RoleCountSetting> RoleCount;

		public struct RolesCount
		{
			public int Origin;
			public int Invader;
			public int End;
			public int Seed;

			public RolesCount(int origin, int invader, int end, int seed)
			{
				Origin = origin;
				Invader = invader;
				End = end;
				Seed = seed;
			}

			public int Total
			{
				get { return Origin + Invader + End + Seed; }
			}
		}

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
			public int SeedCount;

			/// <summary>
			/// Gets the roles count.
			/// </summary>
			/// <returns>count of roles in array [origin, invader, end, seed]</returns>
			public RolesCount GetRolesCount()
			{
				var endCount = !IsRandom
					? EndCount
					: UnityEngine.Random.Range(0, RandomCount + 1);

				return new RolesCount
				(
					OriginCount,
					InvaderCount,
					endCount,
					IsRandom ? RandomCount - endCount : SeedCount
				);
			}

			public int Sum()
			{
				return OriginCount + InvaderCount + (IsRandom ? RandomCount : EndCount + SeedCount);
			}
		}

		public RolesCount GetRolesCount(int playerCount)
		{
			var setting = RoleCount.Where(rc => rc.PlayerCount == playerCount).FirstOrDefault();

			if(setting == null)
			{
				throw new Exception("no role setting for " + playerCount + " players");
			}

			return setting.GetRolesCount();
		}
	}

}
