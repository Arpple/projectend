//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public End.Game.CharacterIconComponent characterIcon { get { return (End.Game.CharacterIconComponent)GetComponent(GameComponentsLookup.CharacterIcon); } }
    public bool hasCharacterIcon { get { return HasComponent(GameComponentsLookup.CharacterIcon); } }

    public void AddCharacterIcon(End.UI.Icon newIconObject) {
        var component = CreateComponent<End.Game.CharacterIconComponent>(GameComponentsLookup.CharacterIcon);
        component.IconObject = newIconObject;
        AddComponent(GameComponentsLookup.CharacterIcon, component);
    }

    public void ReplaceCharacterIcon(End.UI.Icon newIconObject) {
        var component = CreateComponent<End.Game.CharacterIconComponent>(GameComponentsLookup.CharacterIcon);
        component.IconObject = newIconObject;
        ReplaceComponent(GameComponentsLookup.CharacterIcon, component);
    }

    public void RemoveCharacterIcon() {
        RemoveComponent(GameComponentsLookup.CharacterIcon);
    }
}
