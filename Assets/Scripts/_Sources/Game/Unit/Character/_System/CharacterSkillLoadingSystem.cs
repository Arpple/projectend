using UnityEngine;
using System.Collections;
using Entitas;
using System.Linq;

namespace Game
{
	public class CharacterSkillLoadingSystem : IInitializeSystem
	{
		private UnitContext _unitContext;
		private CardContext _cardContext;

		public CharacterSkillLoadingSystem(Contexts contexts)
		{
			_unitContext = contexts.unit;
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

		private UnitEntity[] GetCharacters()
		{
			return _unitContext.GetEntities(UnitMatcher.GameCharacter)
				.Where(c => c.hasGameCharacterSkillsResource)
				.OrderBy(c => c.gameUnit.OwnerEntity.gamePlayer.PlayerId)
				.ToArray();
		}
	}

}
