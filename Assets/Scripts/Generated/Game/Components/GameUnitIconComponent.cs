//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public End.Game.UnitIconComponent unitIcon { get { return (End.Game.UnitIconComponent)GetComponent(GameComponentsLookup.UnitIcon); } }
    public bool hasUnitIcon { get { return HasComponent(GameComponentsLookup.UnitIcon); } }

    public void AddUnitIcon(UnityEngine.Sprite newIconSprite) {
        var component = CreateComponent<End.Game.UnitIconComponent>(GameComponentsLookup.UnitIcon);
        component.IconSprite = newIconSprite;
        AddComponent(GameComponentsLookup.UnitIcon, component);
    }

    public void ReplaceUnitIcon(UnityEngine.Sprite newIconSprite) {
        var component = CreateComponent<End.Game.UnitIconComponent>(GameComponentsLookup.UnitIcon);
        component.IconSprite = newIconSprite;
        ReplaceComponent(GameComponentsLookup.UnitIcon, component);
    }

    public void RemoveUnitIcon() {
        RemoveComponent(GameComponentsLookup.UnitIcon);
    }
}