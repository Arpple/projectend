public class DataLoadingSystems : Feature
{
	public DataLoadingSystems(Contexts contexts, Setting setting) : base("Data Loading")
	{
		///game
		Add(new GameResouceLoadingSystem(contexts));

		//tile
		Add(new TileViewLoadingSystem(contexts, setting.MapSetting.TileSetting));

		//unit
		Add(new UnitViewLoadingSystem(contexts, setting.UnitSetting));

		//card
		Add(new CardBlueprintLoadingSystem(contexts, setting.CardSetting.DeckSetting));
		Add(new CardResoucesLoadingSystem(contexts, setting.CardSetting));

		Add(new AbilityResourceLoadingSystem(contexts));
	}
}
