using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End
{
	[Game]
	public class PlayerComponent : IComponent
	{
		public Player PlayerObject;

		public int PlayerId
		{
			get { return PlayerObject.PlayerId; }
		}
	}

}
