//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public End.Game.PlayerComponent player { get { return (End.Game.PlayerComponent)GetComponent(GameComponentsLookup.Player); } }
    public bool hasPlayer { get { return HasComponent(GameComponentsLookup.Player); } }

    public void AddPlayer(End.Player newPlayerObject) {
        var component = CreateComponent<End.Game.PlayerComponent>(GameComponentsLookup.Player);
        component.PlayerObject = newPlayerObject;
        AddComponent(GameComponentsLookup.Player, component);
    }

    public void ReplacePlayer(End.Player newPlayerObject) {
        var component = CreateComponent<End.Game.PlayerComponent>(GameComponentsLookup.Player);
        component.PlayerObject = newPlayerObject;
        ReplaceComponent(GameComponentsLookup.Player, component);
    }

    public void RemovePlayer() {
        RemoveComponent(GameComponentsLookup.Player);
    }
}
