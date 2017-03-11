﻿using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;
using UnityEngine;

namespace End
{
	public class LoadCharacterSystem : LoadUnitSystem
	{
		const string CHARACTER_VIEW_CONTAINER = "View/Character";

		readonly CharacterSetting _setting;

		public LoadCharacterSystem(Contexts contexts, CharacterSetting setting)
			: base(contexts)
		{
			_setting = setting;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Character, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasCharacter;
		}

		protected override Blueprint GetUnitBlueprint(GameEntity unitEntity)
		{
			return _setting.GetCharBlueprint(unitEntity.character.Type);
		}

		protected override void Execute(List<GameEntity> entities)
		{
			base.Execute(entities);
			foreach(var e in entities)
			{
				e.AddViewContainer(CHARACTER_VIEW_CONTAINER);
			}
		}
	}

}
