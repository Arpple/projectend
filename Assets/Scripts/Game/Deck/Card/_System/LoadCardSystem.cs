using Entitas;
using Entitas.Blueprints;

namespace End.Game
{
	public class LoadCardSystem : LoadBlueprintSystem
	{
		readonly CardSetting _setting;

		public LoadCardSystem(Contexts contexts, CardSetting setting)
			: base(contexts)
		{
			_setting = setting;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Card);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasCard;
		}

		protected override Blueprint GetBlueprint(GameEntity entity)
		{
			return _setting.GetCardBlueprint(entity.card.Type);
		}
	}
}
