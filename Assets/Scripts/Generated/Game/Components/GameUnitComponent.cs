//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.UnitComponent unit { get { return (Game.UnitComponent)GetComponent(GameComponentsLookup.Unit); } }
    public bool hasUnit { get { return HasComponent(GameComponentsLookup.Unit); } }

    public void AddUnit(int newId, GameEntity newOwnerEntity) {
        var component = CreateComponent<Game.UnitComponent>(GameComponentsLookup.Unit);
        component.Id = newId;
        component.OwnerEntity = newOwnerEntity;
        AddComponent(GameComponentsLookup.Unit, component);
    }

    public void ReplaceUnit(int newId, GameEntity newOwnerEntity) {
        var component = CreateComponent<Game.UnitComponent>(GameComponentsLookup.Unit);
        component.Id = newId;
        component.OwnerEntity = newOwnerEntity;
        ReplaceComponent(GameComponentsLookup.Unit, component);
    }

    public void RemoveUnit() {
        RemoveComponent(GameComponentsLookup.Unit);
    }
}
