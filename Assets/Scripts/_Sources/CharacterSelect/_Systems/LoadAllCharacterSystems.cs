using System;
using Entitas;
using Entitas.Blueprints;
using Game;

namespace CharacterSelect
{
	public class LoadAllCharacterSystems : IInitializeSystem
	{
		readonly UnitContext _context;
		readonly CharacterSetting _setting;

		public LoadAllCharacterSystems(Contexts contexts, CharacterSetting setting)
		{
			_context = contexts.unit;
			_setting = setting;
		}

		public void Initialize()
		{
			foreach(var character in Enum.GetValues(typeof(Character)))
			{
				var c = (Character)character;
                var entity = _context.CreateEntity();
				entity.ApplyBlueprint(_setting.GetCharBlueprint(c));
				entity.AddGameCharacter(c);
			}
		}
	}

}
