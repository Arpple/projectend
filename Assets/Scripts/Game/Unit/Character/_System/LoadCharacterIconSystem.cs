using Entitas;
using System.Collections.Generic;
using UnityEngine;
using End.UI;

namespace End.Game
{
	public class LoadCharacterIconSystem : ReactiveSystem<GameEntity>
	{
		public static string GetIconPath(ResourceComponent res)
		{
			var pathArray = res.SpritePath.Split('/');
			pathArray[pathArray.Length - 1] = "";
			return string.Join("/", pathArray) + "Icon";
		}

		readonly CharacterSetting _setting;

		public LoadCharacterIconSystem(Contexts contexts, CharacterSetting setting)
			: base(contexts.game)
		{
			_setting = setting;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Character, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasCharacter && entity.hasResource && !entity.hasCharacterIcon;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				Icon icon = Object.Instantiate(_setting.CharacterIconPrefabs);
				icon.SetImage(Resources.Load<Sprite>(GetIconPath(e.resource)));
				e.AddCharacterIcon(icon);
			}
		}
	}

}
