using Entitas;

namespace End.Game
{
	public class DataLoadingSystem : Feature
	{
		public DataLoadingSystem(Contexts contexts, GameSetting setting) : base("Data Loading System")
		{
			Add(new LoadResourceSystem(contexts));

			Add(new LoadDeckCardSystem(contexts, setting.CardSetting));
			Add(new LoadCharacterSystem(contexts, setting.UnitSetting.CharacterSetting));
		}
	}

}
