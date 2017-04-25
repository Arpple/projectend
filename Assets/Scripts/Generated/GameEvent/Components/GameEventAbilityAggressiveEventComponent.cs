//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEventEntity {

    public AbilityAggressiveEventComponent abilityAggressiveEvent { get { return (AbilityAggressiveEventComponent)GetComponent(GameEventComponentsLookup.AbilityAggressiveEvent); } }
    public bool hasAbilityAggressiveEvent { get { return HasComponent(GameEventComponentsLookup.AbilityAggressiveEvent); } }

    public void AddAbilityAggressiveEvent(UnitEntity newTarget, int newBlockCount, AbilityAggressiveEventComponent.AbilityFunction newActiveAbilityFunction) {
        var index = GameEventComponentsLookup.AbilityAggressiveEvent;
        var component = CreateComponent<AbilityAggressiveEventComponent>(index);
        component.target = newTarget;
        component.blockCount = newBlockCount;
        component.activeAbilityFunction = newActiveAbilityFunction;
        AddComponent(index, component);
    }

    public void ReplaceAbilityAggressiveEvent(UnitEntity newTarget, int newBlockCount, AbilityAggressiveEventComponent.AbilityFunction newActiveAbilityFunction) {
        var index = GameEventComponentsLookup.AbilityAggressiveEvent;
        var component = CreateComponent<AbilityAggressiveEventComponent>(index);
        component.target = newTarget;
        component.blockCount = newBlockCount;
        component.activeAbilityFunction = newActiveAbilityFunction;
        ReplaceComponent(index, component);
    }

    public void RemoveAbilityAggressiveEvent() {
        RemoveComponent(GameEventComponentsLookup.AbilityAggressiveEvent);
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

    static Entitas.IMatcher<GameEventEntity> _matcherAbilityAggressiveEvent;

    public static Entitas.IMatcher<GameEventEntity> AbilityAggressiveEvent {
        get {
            if(_matcherAbilityAggressiveEvent == null) {
                var matcher = (Entitas.Matcher<GameEventEntity>)Entitas.Matcher<GameEventEntity>.AllOf(GameEventComponentsLookup.AbilityAggressiveEvent);
                matcher.componentNames = GameEventComponentsLookup.componentNames;
                _matcherAbilityAggressiveEvent = matcher;
            }

            return _matcherAbilityAggressiveEvent;
        }
    }
}