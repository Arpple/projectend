using System;
using Entitas;

namespace Lounge
{
	public class CharacterLoadingSystems : IInitializeSystem
	{
		readonly UnitContext _context;

		public CharacterLoadingSystems(Contexts contexts)
		{
			_context = contexts.unit;
		}

		public void Initialize()
		{
			foreach(var character in Enum.GetValues(typeof(Character)))
			{
				var c = (Character)character;
                var entity = _context.CreateEntity();
				entity.AddCharacter(c);
			}
		}
	}

}
