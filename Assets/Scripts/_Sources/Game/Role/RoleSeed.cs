using UnityEngine;
using System;

namespace End.Game
{
	public class RoleSeed : Role
	{
		public RoleSeed(GameContext context) : base(context)
		{
		}

		public override string Name
		{
			get
			{
				return "Seed";
			}
		}

		public override string Description
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override string GoalDescription
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override string IconPath
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}

}
