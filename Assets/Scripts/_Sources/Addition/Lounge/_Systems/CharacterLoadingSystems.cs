using System;
using Entitas;
using Entitas.Blueprints;


namespace Lounge
{
	public class CharacterLoadingSystems : IInitializeSystem
	{
		readonly UnitContext _context;
		readonly CharacterSetting _setting;

		public CharacterLoadingSystems(Contexts contexts, CharacterSetting setting)
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
				entity.AddCharacter(c);
			}
		}
	}

}
