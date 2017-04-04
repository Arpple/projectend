using System;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Game
{
	//TODO: implement
	public class RoleOrigin : RoleObject
	{
		public RoleOrigin(GameContext context) : base(context)
		{
		}

		public override string Name
		{
			get { return "End"; }
		}

		public override Role Type
		{
			get { return Role.Origin; }
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
		//		&& _context.GetEntities(GameMatcher.GameRole)
		//		.Where(r => r.gameRole.RoleObject is RoleInvader)
		//		.All(x => x.isGameDead);
		//}
	}
}

