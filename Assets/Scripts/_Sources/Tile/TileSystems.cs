using UnityEngine;

public class TileSystems : Feature
{
	public TileSystems(Contexts contexts, TileSetting setting, GameObject tileContainer, GameUI ui) : base("Tile Systems")
	{
		//init
		Add(new TileMapCreatingSystem(contexts, setting.GameMap));
		Add(new TileGraphCreatingSystem(contexts));
		
		//execute
		Add(new TileDataLoadingSystem(contexts, setting));
		Add(new TileViewCreatingSystem(contexts, setting, tileContainer));
		Add(new TileSpriteUpdateSystem(contexts));
		Add(new TilePositionRenderingSystem(contexts));
		Add(new TileActionSystem(contexts));
		Add(new DefaultTileActionSetupSystem(contexts, ui.TargetPlayerStatus));
		Add(new TileResourceChargeSetupSystem(contexts, setting.TileResourceChargeWeigth));
		Add(new TileResourceSpriteUpdateSystem(contexts));
	}
}

