using Entitas.Blueprints;
using Entitas.Blueprints.Unity;
using System;
using UI;

namespace Game
{
	[Serializable]
	public class CharacterSetting
	{
		const string BLUEPRINT_ENUM_PREFIX = "Char_";

		public JsonBlueprints CharacterBlueprints;
		public Icon CharacterIconPrefabs;

		public Blueprint GetCharBlueprint(Character cha)
		{
			return CharacterBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + cha);
		}
	}

}

