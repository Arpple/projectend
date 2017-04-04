using UnityEngine;
using System.Collections;
using Entitas;
using System.Linq;

namespace Game
{
	public class CharacterSkillLoadingSystem : IInitializeSystem
	{
		private GameContext _context;

		public CharacterSkillLoadingSystem(Contexts contexts)
		{
			_context = contexts.game;
		}

		public void Initialize()
		{
			foreach(var c in GetCharacters())
			{
				foreach (var skill in c.gameCharacterSkillsResource.Skills)
				{
					var skillCard = _context.CreateCard(skill);
					skillCard.isGameSkillCard = true;
					skillCard.AddGamePlayerCard(c.gameUnit.OwnerEntity);
				}
			}
		}

		private GameEntity[] GetCharacters()
		{
			return _context.GetEntities(GameMatcher.GameCharacter)
				.Where(c => c.hasGameCharacterSkillsResource)
				.OrderBy(c => c.gameUnit.OwnerEntity.gamePlayer.PlayerId)
				.ToArray();
		}
	}

}
