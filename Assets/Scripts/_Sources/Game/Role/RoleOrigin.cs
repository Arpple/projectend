using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game
{
	//TODO: implement
	public class RoleOrigin : Role
	{
		public override string Name
		{
			get { return "Origin"; }
		}

		public override string Description
		{
			get
			{
				return "Origin is ...";
			}
		}

		public override string GoalDescription
		{
			get
			{
				return "To win ...";
			}
		}

		public override string IconPath
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override bool IsWin(GameContext context, GameEntity entity)
		{
			return base.IsWin(context, entity);
		}
	}
}

