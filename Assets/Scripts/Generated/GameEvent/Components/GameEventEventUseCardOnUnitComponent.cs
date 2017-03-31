//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEventEntity {

    public End.Game.EventUseCardOnUnit eventUseCardOnUnit { get { return (End.Game.EventUseCardOnUnit)GetComponent(GameEventComponentsLookup.EventUseCardOnUnit); } }
    public bool hasEventUseCardOnUnit { get { return HasComponent(GameEventComponentsLookup.EventUseCardOnUnit); } }

    public void AddEventUseCardOnUnit(GameEntity newUserEntity, GameEntity newCardEnttiy, GameEntity newTargetEnttiy) {
        var component = CreateComponent<End.Game.EventUseCardOnUnit>(GameEventComponentsLookup.EventUseCardOnUnit);
        component.UserEntity = newUserEntity;
        component.CardEnttiy = newCardEnttiy;
        component.TargetEnttiy = newTargetEnttiy;
        AddComponent(GameEventComponentsLookup.EventUseCardOnUnit, component);
    }

    public void ReplaceEventUseCardOnUnit(GameEntity newUserEntity, GameEntity newCardEnttiy, GameEntity newTargetEnttiy) {
        var component = CreateComponent<End.Game.EventUseCardOnUnit>(GameEventComponentsLookup.EventUseCardOnUnit);
        component.UserEntity = newUserEntity;
        component.CardEnttiy = newCardEnttiy;
        component.TargetEnttiy = newTargetEnttiy;
        ReplaceComponent(GameEventComponentsLookup.EventUseCardOnUnit, component);
    }

    public void RemoveEventUseCardOnUnit() {
        RemoveComponent(GameEventComponentsLookup.EventUseCardOnUnit);
    }
}
