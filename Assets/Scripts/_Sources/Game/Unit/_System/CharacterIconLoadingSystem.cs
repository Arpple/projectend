using UnityEngine;
using System.Collections;
using Entitas;
using System;

namespace Game
{
	public class CharacterIconLoadingSystem : IInitializeSystem
	{
		private readonly UnitContext _context;

		public CharacterIconLoadingSystem(Contexts contexts)
		{
			_context = contexts.unit;
		}

		public void Initialize()
		{
			var characters = _context.GetEntities(UnitMatcher.GameCharacter);

			foreach(var character in characters)
			{
				if (character.hasGameUnitIconResource && !character.hasGameUnitIcon)
				{
					character.AddGameUnitIcon(Resources.Load<Sprite>(character.gameUnitIconResource.IconSpritePath));
				}
			}
		}
	}
}
