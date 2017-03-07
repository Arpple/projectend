//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public End.TileComponent tile { get { return (End.TileComponent)GetComponent(GameComponentsLookup.Tile); } }
    public bool hasTile { get { return HasComponent(GameComponentsLookup.Tile); } }

    public void AddTile(End.Tile newType) {
        var component = CreateComponent<End.TileComponent>(GameComponentsLookup.Tile);
        component.Type = newType;
        AddComponent(GameComponentsLookup.Tile, component);
    }

    public void ReplaceTile(End.Tile newType) {
        var component = CreateComponent<End.TileComponent>(GameComponentsLookup.Tile);
        component.Type = newType;
        ReplaceComponent(GameComponentsLookup.Tile, component);
    }

    public void RemoveTile() {
        RemoveComponent(GameComponentsLookup.Tile);
    }
}
