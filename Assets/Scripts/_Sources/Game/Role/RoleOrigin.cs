using System;

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
}
