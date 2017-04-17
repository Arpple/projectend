using System.Linq;
using Entitas;

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
		foreach (var c in GetCharacters())
		{
			foreach (var skill in c.characterSkillsResource.Skills)
			{
				var skillCard = _cardContext.CreateEntity();
				skillCard.AddSkillCard(skill);
				skillCard.AddOwner(c.owner.Entity);
			}
		}
	}

	private UnitEntity[] GetCharacters()
	{
		return _unitContext.GetEntities(UnitMatcher.Character)
			.Where(c => c.hasCharacterSkillsResource)
			.OrderBy(c => c.owner.Entity.player.PlayerId)
			.ToArray();
	}
}