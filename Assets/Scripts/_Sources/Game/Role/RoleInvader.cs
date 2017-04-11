using System;

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

}