using UnityEngine;
using System.Collections;
using Entitas;
using System;

namespace Game
{
	public class CharacterIconLoadingSystem : IInitializeSystem
	{
		private readonly GameContext _context;

		public CharacterIconLoadingSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			var characters = _context.GetEntities(GameMatcher.GameCharacter);

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
