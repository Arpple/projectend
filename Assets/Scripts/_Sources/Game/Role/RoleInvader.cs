using System;
using System.Linq;
using Entitas;
using UnityEngine;

namespace End.Game
{
	//TODO: implement
	public class RoleInvader : RoleObject
	{
		public RoleInvader(GameContext context) : base(context)
		{
		}

		public override string Name
		{
			get { return "End"; }
		}

		public override Role Type
		{
			get { return Role.Invader; }
		}

		public override string Description
		{
			get
			{
				return "";
			}
		}

		public override string GoalDescription
		{
			get
			{
				return "";
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
		//			.Where(r => r.role.RoleObject is RoleOrigin)
		//			.Select(p => GameUtil.GetCharacterFromPlayer(p))
		//			.All(x => x.isDead);
		//}
	}
}

