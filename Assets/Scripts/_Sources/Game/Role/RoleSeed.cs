using System;

public class RoleSeed : RoleObject
{
	public RoleSeed(GameContext context) : base(context)
	{
	}

	public override string Name
	{
		get { return "End"; }
	}

	public override Role Type
	{
		get { return Role.Seed; }
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