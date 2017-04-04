using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	[Game]
	public class CharacterSkillsResourceComponent : IComponent
	{
		public List<Card> Skills;
	}
}
