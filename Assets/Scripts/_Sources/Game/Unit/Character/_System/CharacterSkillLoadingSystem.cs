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
				foreach (var skill in c.characterSkillsResource.Skills)
				{
					var skillCard = _context.CreateCard(skill);
					skillCard.isSkillCard = true;
					skillCard.AddPlayerCard(c.unit.OwnerEntity);
				}
			}
		}

		private GameEntity[] GetCharacters()
		{
			return _context.GetEntities(GameMatcher.Character)
				.Where(c => c.hasCharacterSkillsResource)
				.OrderBy(c => c.unit.OwnerEntity.player.PlayerId)
				.ToArray();
		}
	}

}
