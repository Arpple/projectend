using Entitas;

namespace End.Game
{
	public class DataLoadingSystem : Feature
	{
		public DataLoadingSystem(Contexts contexts, GameSetting setting) : base("Data Loading")
		{
			Add(new LoadDeckCardSystem(contexts, setting.CardSetting.DeckSetting));
			Add(new LoadAbilitySystem(contexts));
			Add(new LoadResourceSystem(contexts));
		}
	}

}
