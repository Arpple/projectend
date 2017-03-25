﻿using System.Collections.Generic;
using Entitas;

namespace End.Game
{
	public class GameSetupSystem : Feature
	{
		public GameSetupSystem(Contexts contexts, GameSetting setting, List<Player> players) : base("Game Setup")
		{
			//player
			Add(new LoadPlayerSystem(contexts, players));
			Add(new SetupLocalPlayerSystem(contexts));
			Add(new CreatePlayerCharacterSystem(contexts));

			//map
			Add(new CreateMapTileSystem(contexts, setting.MapSetting.GameMap.Load(), setting.MapSetting));
			Add(new CreateTileGraphSystem(contexts));
			Add(new CreateTileActionSystem(contexts));

			//card
			Add(new CreateDeckCardsSystem(contexts, setting.DeckSetting.CardSetting.Deck));
		}
	}
}

