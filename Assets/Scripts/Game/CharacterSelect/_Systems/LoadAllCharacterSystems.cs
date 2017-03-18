﻿using System;
using Entitas;
using UnityEngine;
using Entitas.Blueprints;

namespace End.Game.CharacterSelect
{
	public class LoadAllCharacterSystems : IInitializeSystem
	{
		readonly GameContext _context;
		readonly CharacterSetting _setting;

		public LoadAllCharacterSystems(Contexts contexts, CharacterSetting setting)
		{
			_context = contexts.game;
			_setting = setting;
		}

		public void Initialize()
		{
			foreach(var character in Enum.GetValues(typeof(Character)))
			{
				var entity = _context.CreateEntity();
				entity.ApplyBlueprint(_setting.GetCharBlueprint((Character)character));
				entity.AddCharacter((Character)character);
			}
		}
	}

}
