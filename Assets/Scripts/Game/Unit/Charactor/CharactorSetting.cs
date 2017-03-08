using Entitas.Blueprints;
using Entitas.Unity.Blueprints;
using System;

namespace End
{
	[Serializable]
	public class CharactorSetting
	{
		const string BLUEPRINT_ENUM_PREFIX = "Char_";

		public Blueprints CharactorBlueprints;

		public Blueprint GetCharBlueprint(Charactor cha)
		{
			return CharactorBlueprints.GetBlueprint(BLUEPRINT_ENUM_PREFIX + cha);
		}
	}

}

