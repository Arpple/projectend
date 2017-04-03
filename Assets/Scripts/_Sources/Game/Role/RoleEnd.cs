using System;

namespace End.Game
{
	public class RoleEnd : RoleObject
	{
		public RoleEnd(GameContext context) : base(context)
		{
		}

		public override string Name
		{
			get { return "End"; }
		}

		public override Role Type
		{
			get { return Role.End; }
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
