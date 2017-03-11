using Entitas.Blueprints;
using Entitas.Unity.Blueprints;
using System;

namespace End.Game
{
	[Serializable]
	public class CharacterSetting
	{
		const string BLUEPRINT_ENUM_PREFIX = "Char_";

		public Blueprints CharacterBlueprints;

		public Blueprint GetCharBlueprint(Character cha)
		{
			return CharacterBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + cha);
		}
	}

}

