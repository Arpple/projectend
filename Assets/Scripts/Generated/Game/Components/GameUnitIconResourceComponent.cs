//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public End.Game.UnitIconResourceComponent unitIconResource { get { return (End.Game.UnitIconResourceComponent)GetComponent(GameComponentsLookup.UnitIconResource); } }
    public bool hasUnitIconResource { get { return HasComponent(GameComponentsLookup.UnitIconResource); } }

    public void AddUnitIconResource(string newIconSpritePath) {
        var component = CreateComponent<End.Game.UnitIconResourceComponent>(GameComponentsLookup.UnitIconResource);
        component.IconSpritePath = newIconSpritePath;
        AddComponent(GameComponentsLookup.UnitIconResource, component);
    }

    public void ReplaceUnitIconResource(string newIconSpritePath) {
        var component = CreateComponent<End.Game.UnitIconResourceComponent>(GameComponentsLookup.UnitIconResource);
        component.IconSpritePath = newIconSpritePath;
        ReplaceComponent(GameComponentsLookup.UnitIconResource, component);
    }

    public void RemoveUnitIconResource() {
        RemoveComponent(GameComponentsLookup.UnitIconResource);
    }
}