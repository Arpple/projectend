//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEventEntity {

    public EventCreateWeather eventCreateWeather { get { return (EventCreateWeather)GetComponent(GameEventComponentsLookup.EventCreateWeather); } }
    public bool hasEventCreateWeather { get { return HasComponent(GameEventComponentsLookup.EventCreateWeather); } }

    public void AddEventCreateWeather(Weather newType, System.Collections.Generic.Dictionary<Resource, int> newCostMap) {
        var index = GameEventComponentsLookup.EventCreateWeather;
        var component = CreateComponent<EventCreateWeather>(index);
        component.Type = newType;
        component.CostMap = newCostMap;
        AddComponent(index, component);
    }

    public void ReplaceEventCreateWeather(Weather newType, System.Collections.Generic.Dictionary<Resource, int> newCostMap) {
        var index = GameEventComponentsLookup.EventCreateWeather;
        var component = CreateComponent<EventCreateWeather>(index);
        component.Type = newType;
        component.CostMap = newCostMap;
        ReplaceComponent(index, component);
    }

    public void RemoveEventCreateWeather() {
        RemoveComponent(GameEventComponentsLookup.EventCreateWeather);
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

    static Entitas.IMatcher<GameEventEntity> _matcherEventCreateWeather;

    public static Entitas.IMatcher<GameEventEntity> EventCreateWeather {
        get {
            if(_matcherEventCreateWeather == null) {
                var matcher = (Entitas.Matcher<GameEventEntity>)Entitas.Matcher<GameEventEntity>.AllOf(GameEventComponentsLookup.EventCreateWeather);
                matcher.componentNames = GameEventComponentsLookup.componentNames;
                _matcherEventCreateWeather = matcher;
            }

            return _matcherEventCreateWeather;
        }
    }
}
