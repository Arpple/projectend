using UnityEngine;
using System.Collections;
using Entitas;

namespace Game
{
	[Unit]
	public class UnitDetailComponent : IComponent
	{
		public string Name;
		public string Description;
	}
}
