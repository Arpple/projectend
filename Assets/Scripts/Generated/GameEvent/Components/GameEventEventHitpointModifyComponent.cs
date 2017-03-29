//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEventEntity {

    public End.Game.EventHitpointModify eventHitpointModify { get { return (End.Game.EventHitpointModify)GetComponent(GameEventComponentsLookup.EventHitpointModify); } }
    public bool hasEventHitpointModify { get { return HasComponent(GameEventComponentsLookup.EventHitpointModify); } }

    public void AddEventHitpointModify(GameEntity newSourceUnit, GameEntity newTargetUnit, int newValue, End.Game.HitPointModifyType newType) {
        var component = CreateComponent<End.Game.EventHitpointModify>(GameEventComponentsLookup.EventHitpointModify);
        component.SourceUnit = newSourceUnit;
        component.TargetUnit = newTargetUnit;
        component.Value = newValue;
        component.Type = newType;
        AddComponent(GameEventComponentsLookup.EventHitpointModify, component);
    }

    public void ReplaceEventHitpointModify(GameEntity newSourceUnit, GameEntity newTargetUnit, int newValue, End.Game.HitPointModifyType newType) {
        var component = CreateComponent<End.Game.EventHitpointModify>(GameEventComponentsLookup.EventHitpointModify);
        component.SourceUnit = newSourceUnit;
        component.TargetUnit = newTargetUnit;
        component.Value = newValue;
        component.Type = newType;
        ReplaceComponent(GameEventComponentsLookup.EventHitpointModify, component);
    }

    public void RemoveEventHitpointModify() {
        RemoveComponent(GameEventComponentsLookup.EventHitpointModify);
    }
}
