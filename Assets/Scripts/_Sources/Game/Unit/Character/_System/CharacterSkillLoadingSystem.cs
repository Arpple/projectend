using UnityEngine;
using System.Collections;
using Entitas;
using System.Linq;

namespace Game
{
	public class CharacterSkillLoadingSystem : IInitializeSystem
	{
		private GameContext _gameContext;
		private CardContext _cardContext;

		public CharacterSkillLoadingSystem(Contexts contexts)
		{
			_gameContext = contexts.game;
			_cardContext = contexts.card;
		}

		public void Initialize()
		{
			foreach(var c in GetCharacters())
			{
				foreach (var skill in c.gameCharacterSkillsResource.Skills)
				{
					var skillCard = _cardContext.CreateCard(skill);
					skillCard.isGameSkillCard = true;
					skillCard.AddGameOwner(c.gameUnit.OwnerEntity);
				}
			}
		}

		private GameEntity[] GetCharacters()
		{
			return _gameContext.GetEntities(GameMatcher.GameCharacter)
				.Where(c => c.hasGameCharacterSkillsResource)
				.OrderBy(c => c.gameUnit.OwnerEntity.gamePlayer.PlayerId)
				.ToArray();
		}
	}

}
