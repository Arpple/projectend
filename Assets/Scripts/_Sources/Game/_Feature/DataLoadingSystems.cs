using Entitas;

namespace Game
{
	public class DataLoadingSystems : Feature
	{
		public DataLoadingSystems(Contexts contexts, GameSetting setting) : base("Data Loading")
		{
			///game
			Add(new GameResouceLoadSystem(contexts));

			//tile
			Add(new TileViewLoadingSystem(contexts, setting.MapSetting.TileSetting));

			//unit
			Add(new UnitViewLoadingSystem(contexts, setting.UnitSetting));

			//card
			Add(new LoadCardSystem(contexts, setting.CardSetting.DeckSetting));
			Add(new CardViewLoadingSystem(contexts, setting.CardSetting));

			Add(new AbilityResourceLoadingSystem(contexts));
		}
	}

}
