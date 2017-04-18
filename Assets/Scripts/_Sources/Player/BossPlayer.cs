using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BossPlayer : IPlayer
{
	public int GetId()
	{
		return -1;
	}

	public string GetName()
	{
		return "-Boss-";
	}
}