using Entitas.Blueprints;
using Entitas.Blueprints.Unity;
using System;
using UI;


[Serializable]
public class CharacterSetting
{
	const string BLUEPRINT_ENUM_PREFIX = "Char_";

	public Icon CharacterIconPrefabs;

	public Blueprint GetCharBlueprint(Character cha)
	{
		return null;
		//return CharacterBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + cha);
	}
}

