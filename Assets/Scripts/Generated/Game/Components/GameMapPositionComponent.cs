//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public End.MapPositionComponent mapPosition { get { return (End.MapPositionComponent)GetComponent(GameComponentsLookup.MapPosition); } }
    public bool hasMapPosition { get { return HasComponent(GameComponentsLookup.MapPosition); } }

    public void AddMapPosition(int newX, int newY) {
        var component = CreateComponent<End.MapPositionComponent>(GameComponentsLookup.MapPosition);
        component.X = newX;
        component.Y = newY;
        AddComponent(GameComponentsLookup.MapPosition, component);
    }

    public void ReplaceMapPosition(int newX, int newY) {
        var component = CreateComponent<End.MapPositionComponent>(GameComponentsLookup.MapPosition);
        component.X = newX;
        component.Y = newY;
        ReplaceComponent(GameComponentsLookup.MapPosition, component);
    }

    public void RemoveMapPosition() {
        RemoveComponent(GameComponentsLookup.MapPosition);
    }
}
