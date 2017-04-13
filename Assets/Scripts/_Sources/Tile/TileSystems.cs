using UnityEngine;

public class TileSystems : Feature
{
	public TileSystems(Contexts contexts, TileSetting setting, GameObject tileContainer, GameUI ui) : base("Tile Systems")
	{
		//init
		Add(new TileMapCreatingSystem(contexts, setting.GameMap));
		Add(new TileGraphCreatingSystem(contexts));
		Add(new TileResourceCreatingSystem(contexts));
		Add(new TileResourceChargeSetupSystem(contexts, setting.TileResourceChargeWeigth));

		//execute
		Add(new TileDataLoadingSystem(contexts, setting));
		Add(new TileViewCreatingSystem(contexts, setting, tileContainer));
		Add(new TilePositionRenderingSystem(contexts));
		Add(new TileActionSystem(contexts));
		Add(new DefaultTileActionSetupSystem(contexts, ui.TargetPlayerStatus));
	}
}

