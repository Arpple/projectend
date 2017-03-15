//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentsLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Ability = 0;
    public const int Card = 1;
    public const int Character = 2;
    public const int Description = 3;
    public const int MapPosition = 4;
    public const int Player = 5;
    public const int Resource = 6;
    public const int Spawnpoint = 7;
    public const int Tile = 8;
    public const int TileAction = 9;
    public const int TileBrush = 10;
    public const int TileGraph = 11;
    public const int TileHoverAction = 12;
    public const int Unit = 13;
    public const int View = 14;
    public const int ViewContainer = 15;

    public const int TotalComponents = 16;

    public static readonly string[] componentNames = {
        "Ability",
        "Card",
        "Character",
        "Description",
        "MapPosition",
        "Player",
        "Resource",
        "Spawnpoint",
        "Tile",
        "TileAction",
        "TileBrush",
        "TileGraph",
        "TileHoverAction",
        "Unit",
        "View",
        "ViewContainer"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(End.Game.AbilityComponent),
        typeof(End.Game.CardComponent),
        typeof(End.Game.CharacterComponent),
        typeof(End.Game.Role.RoleDescriptionComponent.DescriptionComponent),
        typeof(End.Game.MapPositionComponent),
        typeof(End.Game.PlayerComponent),
        typeof(End.Game.ResourceComponent),
        typeof(End.Game.SpawnpointComponent),
        typeof(End.Game.TileComponent),
        typeof(End.Game.TileActionComponent),
        typeof(End.MapEditor.TileBrushComponent),
        typeof(End.Game.TileGraphComponent),
        typeof(End.Game.TileHoverActionComponent),
        typeof(End.Game.UnitComponent),
        typeof(End.Game.ViewComponent),
        typeof(End.Game.ViewContainerComponent)
    };
}
