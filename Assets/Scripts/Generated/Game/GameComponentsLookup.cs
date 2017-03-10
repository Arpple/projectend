//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentsLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Description = 0;
    public const int MapPosition = 1;
    public const int Resource = 2;
    public const int Spawnpoint = 3;
    public const int Tile = 4;
    public const int TileAction = 5;
    public const int TileBrush = 6;
    public const int TileGraph = 7;
    public const int View = 8;

    public const int TotalComponents = 9;

    public static readonly string[] componentNames = {
        "Description",
        "MapPosition",
        "Resource",
        "Spawnpoint",
        "Tile",
        "TileAction",
        "TileBrush",
        "TileGraph",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(End.Game.Role.Component.RoleDescriptionComponent.DescriptionComponent),
        typeof(End.MapPositionComponent),
        typeof(End.ResourceComponent),
        typeof(End.SpawnpointComponent),
        typeof(End.TileComponent),
        typeof(End.TileActionComponent),
        typeof(End.MapEditor.TileBrushComponent),
        typeof(End.TileGraphComponent),
        typeof(End.ViewComponent)
    };
}
