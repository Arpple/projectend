//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.SpawnpointComponent spawnpoint { get { return (Game.SpawnpointComponent)GetComponent(GameComponentsLookup.Spawnpoint); } }
    public bool hasSpawnpoint { get { return HasComponent(GameComponentsLookup.Spawnpoint); } }

    public void AddSpawnpoint(int newIndex) {
        var component = CreateComponent<Game.SpawnpointComponent>(GameComponentsLookup.Spawnpoint);
        component.index = newIndex;
        AddComponent(GameComponentsLookup.Spawnpoint, component);
    }

    public void ReplaceSpawnpoint(int newIndex) {
        var component = CreateComponent<Game.SpawnpointComponent>(GameComponentsLookup.Spawnpoint);
        component.index = newIndex;
        ReplaceComponent(GameComponentsLookup.Spawnpoint, component);
    }

    public void RemoveSpawnpoint() {
        RemoveComponent(GameComponentsLookup.Spawnpoint);
    }
}
