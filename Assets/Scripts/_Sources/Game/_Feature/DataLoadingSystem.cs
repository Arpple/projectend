using Entitas;

namespace Game
{
	public class DataLoadingSystem : Feature
	{
		public DataLoadingSystem(Contexts contexts, GameSetting setting) : base("Data Loading")
		{
			Add(new LoadCardSystem(contexts, setting.CardSetting.DeckSetting));
			Add(new GameResouceLoadSystem(contexts));
			Add(new UnitViewLoadingSystem(contexts, setting.UnitSetting));
			Add(new CardViewLoadingSystem(contexts, setting.CardSetting));

			Add(new LoadAbilitySystem(contexts));
		}
	}

}
