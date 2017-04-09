using Entitas;
using Game.Offline;

namespace Game
{
	public class DataRenderingSystems : Feature
	{
		public DataRenderingSystems(Contexts contexts, GameSetting _setting) : base("Data Rendering")
		{
			//deck card
			Add(new PlayerDeckRenderingSystem(contexts));
			Add(new BoxCardRenderingSystem(contexts));
			
			//unit
			Add(new OnDeadAbilitySystem(contexts));
			Add(new DeadSystem(contexts));
			Add(new LocalCharacterFlagSystem(contexts));

			//map
			Add(new UnitPositionRenderingSystem(contexts));
			Add(new TilePositionRenderingSystem(contexts));
			Add(new TileActionSystem(contexts));

			//event
			Add(new RoleOriginWinningSystem(contexts));
			Add(new WinSystem(contexts));
			Add(new RoundEndPlayingOrderReOrderingSystem(contexts));
			Add(new PlayingFlagSystem(contexts));

			if (GameController.Instance.IsOffline)
			{
				Add(new LocalFlagPassingSystem(contexts));
			}

			Add(new StartTurnDrawSystem(contexts, _setting.CardSetting.DeckSetting));
		}
	}

}
