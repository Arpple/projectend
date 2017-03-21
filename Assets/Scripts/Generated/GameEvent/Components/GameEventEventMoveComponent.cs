//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEventEntity {

    public End.Game.EventMove eventMove { get { return (End.Game.EventMove)GetComponent(GameEventComponentsLookup.EventMove); } }
    public bool hasEventMove { get { return HasComponent(GameEventComponentsLookup.EventMove); } }

    public void AddEventMove(GameEntity newMovingEntity, int newX, int newY) {
        var component = CreateComponent<End.Game.EventMove>(GameEventComponentsLookup.EventMove);
        component.MovingEntity = newMovingEntity;
        component.x = newX;
        component.y = newY;
        AddComponent(GameEventComponentsLookup.EventMove, component);
    }

    public void ReplaceEventMove(GameEntity newMovingEntity, int newX, int newY) {
        var component = CreateComponent<End.Game.EventMove>(GameEventComponentsLookup.EventMove);
        component.MovingEntity = newMovingEntity;
        component.x = newX;
        component.y = newY;
        ReplaceComponent(GameEventComponentsLookup.EventMove, component);
    }

    public void RemoveEventMove() {
        RemoveComponent(GameEventComponentsLookup.EventMove);
    }
}
