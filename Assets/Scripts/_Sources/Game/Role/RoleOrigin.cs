using System;
using System.Linq;
using Entitas;
using UnityEngine;

namespace End.Game
{
	//TODO: implement
	public class RoleOrigin : Role
	{
		public RoleOrigin(GameContext context) : base(context)
		{
		}

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

		//public override bool IsWin(GameEntity playerEntity)
		//{
		//	return base.IsWin(playerEntity)
		//		&& _context.GetEntities(GameMatcher.Role)
		//		.Where(r => r.role.RoleObject is RoleInvader)
		//		.All(x => x.isDead);
		//}
	}
}

