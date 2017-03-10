using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;
using UnityEngine;

namespace End
{
	public class LoadCharacterSystem : LoadUnitSystem
	{
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
	}

}
