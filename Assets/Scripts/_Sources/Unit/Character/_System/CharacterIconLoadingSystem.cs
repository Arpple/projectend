using Entitas;
using UnityEngine;

public class CharacterIconLoadingSystem : IInitializeSystem
{
	private readonly UnitContext _context;

	public CharacterIconLoadingSystem(Contexts contexts)
	{
		_context = contexts.unit;
	}

	public void Initialize()
	{
		var characters = _context.GetEntities(UnitMatcher.Character);

		foreach (var character in characters)
		{
			if (character.hasUnitIconResource && !character.hasUnitIcon)
			{
				character.AddUnitIcon(Resources.Load<Sprite>(character.unitIconResource.IconSpritePath));
			}
		}
	}
}