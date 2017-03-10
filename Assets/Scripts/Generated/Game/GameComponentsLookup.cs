//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentsLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Character = 0;
    public const int Description = 1;
    public const int MapPosition = 2;
    public const int Player = 3;
    public const int Resource = 4;
    public const int Spawnpoint = 5;
    public const int Tile = 6;
    public const int TileAction = 7;
    public const int TileBrush = 8;
    public const int TileGraph = 9;
    public const int View = 10;

    public const int TotalComponents = 11;

    public static readonly string[] componentNames = {
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
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(End.CharacterComponent),
        typeof(End.Game.Role.Component.RoleDescriptionComponent.DescriptionComponent),
        typeof(End.MapPositionComponent),
        typeof(End.PlayerComponent),
        typeof(End.ResourceComponent),
        typeof(End.SpawnpointComponent),
        typeof(End.TileComponent),
        typeof(End.TileActionComponent),
        typeof(End.MapEditor.TileBrushComponent),
        typeof(End.TileGraphComponent),
        typeof(End.ViewComponent)
    };
}
