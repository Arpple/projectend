﻿using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;

namespace End.Game
{
	public class CharacterBlueprintLoadingSystem : IInitializeSystem
	{
		const string CHARACTER_VIEW_CONTAINER = "View/Character";

		readonly CharacterSetting _setting;
		private readonly GameContext _context;

		public CharacterBlueprintLoadingSystem(Contexts contexts, CharacterSetting setting)
		{
			_setting = setting;
			_context = contexts.game;
		}

		protected Blueprint GetBlueprint(GameEntity entity)
		{
			return _setting.GetCharBlueprint(entity.character.Type);
		}

		protected void LoadUnitData(GameEntity[] entities)
		{
			foreach(var e in entities)
			{
				e.ApplyBlueprint(GetBlueprint(e));
				e.AddViewContainer(CHARACTER_VIEW_CONTAINER);
				e.AddHitpoint(e.unitStatus.HitPoint);
			}
		}

		public void Initialize()
		{
			LoadUnitData(_context.GetEntities(GameMatcher.Character));
		}
	}

}