//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEventEntity {

    public End.Game.EventMoveUnit eventMoveUnit { get { return (End.Game.EventMoveUnit)GetComponent(GameEventComponentsLookup.EventMoveUnit); } }
    public bool hasEventMoveUnit { get { return HasComponent(GameEventComponentsLookup.EventMoveUnit); } }

    public void AddEventMoveUnit(GameEntity newMovingEntity, int newX, int newY) {
        var component = CreateComponent<End.Game.EventMoveUnit>(GameEventComponentsLookup.EventMoveUnit);
        component.MovingEntity = newMovingEntity;
        component.x = newX;
        component.y = newY;
        AddComponent(GameEventComponentsLookup.EventMoveUnit, component);
    }

    public void ReplaceEventMoveUnit(GameEntity newMovingEntity, int newX, int newY) {
        var component = CreateComponent<End.Game.EventMoveUnit>(GameEventComponentsLookup.EventMoveUnit);
        component.MovingEntity = newMovingEntity;
        component.x = newX;
        component.y = newY;
        ReplaceComponent(GameEventComponentsLookup.EventMoveUnit, component);
    }

    public void RemoveEventMoveUnit() {
        RemoveComponent(GameEventComponentsLookup.EventMoveUnit);
    }
}
