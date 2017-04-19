//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEventEntity {

    public EventMoveDeckCard eventMoveDeckCard { get { return (EventMoveDeckCard)GetComponent(GameEventComponentsLookup.EventMoveDeckCard); } }
    public bool hasEventMoveDeckCard { get { return HasComponent(GameEventComponentsLookup.EventMoveDeckCard); } }

    public void AddEventMoveDeckCard(CardEntity newCardEntity, GameEntity newTargetPlayerEntity, bool newIsInBox) {
        var index = GameEventComponentsLookup.EventMoveDeckCard;
        var component = CreateComponent<EventMoveDeckCard>(index);
        component.CardEntity = newCardEntity;
        component.TargetPlayerEntity = newTargetPlayerEntity;
        component.IsInBox = newIsInBox;
        AddComponent(index, component);
    }

    public void ReplaceEventMoveDeckCard(CardEntity newCardEntity, GameEntity newTargetPlayerEntity, bool newIsInBox) {
        var index = GameEventComponentsLookup.EventMoveDeckCard;
        var component = CreateComponent<EventMoveDeckCard>(index);
        component.CardEntity = newCardEntity;
        component.TargetPlayerEntity = newTargetPlayerEntity;
        component.IsInBox = newIsInBox;
        ReplaceComponent(index, component);
    }

    public void RemoveEventMoveDeckCard() {
        RemoveComponent(GameEventComponentsLookup.EventMoveDeckCard);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameEventMatcher {

    static Entitas.IMatcher<GameEventEntity> _matcherEventMoveDeckCard;

    public static Entitas.IMatcher<GameEventEntity> EventMoveDeckCard {
        get {
            if(_matcherEventMoveDeckCard == null) {
                var matcher = (Entitas.Matcher<GameEventEntity>)Entitas.Matcher<GameEventEntity>.AllOf(GameEventComponentsLookup.EventMoveDeckCard);
                matcher.componentNames = GameEventComponentsLookup.componentNames;
                _matcherEventMoveDeckCard = matcher;
            }

            return _matcherEventMoveDeckCard;
        }
    }
}