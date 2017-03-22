//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public End.Game.LocalPlayerComponent localPlayer { get { return (End.Game.LocalPlayerComponent)GetComponent(GameComponentsLookup.LocalPlayer); } }
    public bool hasLocalPlayer { get { return HasComponent(GameComponentsLookup.LocalPlayer); } }

    public void AddLocalPlayer(End.Player newPlayerObject) {
        var component = CreateComponent<End.Game.LocalPlayerComponent>(GameComponentsLookup.LocalPlayer);
        component.PlayerObject = newPlayerObject;
        AddComponent(GameComponentsLookup.LocalPlayer, component);
    }

    public void ReplaceLocalPlayer(End.Player newPlayerObject) {
        var component = CreateComponent<End.Game.LocalPlayerComponent>(GameComponentsLookup.LocalPlayer);
        component.PlayerObject = newPlayerObject;
        ReplaceComponent(GameComponentsLookup.LocalPlayer, component);
    }

    public void RemoveLocalPlayer() {
        RemoveComponent(GameComponentsLookup.LocalPlayer);
    }
}
