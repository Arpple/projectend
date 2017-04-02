using UnityEngine;
using System.Collections;
using Entitas;
using System;

namespace End.Game
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
			var characters = _context.GetEntities(GameMatcher.Character);

			foreach(var character in characters)
			{
				Debug.Log(character.hasUnitIconResource);
				if (character.hasUnitIconResource && !character.hasUnitIcon)
				{
					character.AddUnitIcon(Resources.Load<Sprite>(character.unitIconResource.IconSpritePath));
				}
			}
		}
	}
}
