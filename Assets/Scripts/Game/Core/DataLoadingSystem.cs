using Entitas;

namespace End.Game
{
	public class DataLoadingSystem : Feature
	{
		public DataLoadingSystem(Contexts contexts, GameSetting setting) : base("Data Loading System")
		{
			Add(new LoadCardSystem(contexts, setting.DeckSetting.CardSetting));

			Add(new LoadResourceSystem(contexts));
		}
	}

}
