using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[Unit]
	public class CharacterSkillsResourceComponent : IComponent
	{
		public List<Card> Skills;
	}
}
