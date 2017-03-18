using Entitas.Blueprints;
using Entitas.Unity.Blueprints;
using System;
using End.UI;

namespace End.Game
{
	[Serializable]
	public class CharacterSetting
	{
		const string BLUEPRINT_ENUM_PREFIX = "Char_";

		public Blueprints CharacterBlueprints;
		public Icon CharacterIconPrefabs;

		public Blueprint GetCharBlueprint(Character cha)
		{
			return CharacterBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + cha);
		}
	}

}

