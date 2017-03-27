//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEventEntity {

    public End.Game.EventMoveCard eventMoveCard { get { return (End.Game.EventMoveCard)GetComponent(GameEventComponentsLookup.EventMoveCard); } }
    public bool hasEventMoveCard { get { return HasComponent(GameEventComponentsLookup.EventMoveCard); } }

    public void AddEventMoveCard(GameEntity newCardEntity, int newTargetPlayerId) {
        var component = CreateComponent<End.Game.EventMoveCard>(GameEventComponentsLookup.EventMoveCard);
        component.CardEntity = newCardEntity;
        component.TargetPlayerId = newTargetPlayerId;
        AddComponent(GameEventComponentsLookup.EventMoveCard, component);
    }

    public void ReplaceEventMoveCard(GameEntity newCardEntity, int newTargetPlayerId) {
        var component = CreateComponent<End.Game.EventMoveCard>(GameEventComponentsLookup.EventMoveCard);
        component.CardEntity = newCardEntity;
        component.TargetPlayerId = newTargetPlayerId;
        ReplaceComponent(GameEventComponentsLookup.EventMoveCard, component);
    }

    public void RemoveEventMoveCard() {
        RemoveComponent(GameEventComponentsLookup.EventMoveCard);
    }
}