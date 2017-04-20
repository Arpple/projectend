//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity weatherCostEntity { get { return GetGroup(GameMatcher.WeatherCost).GetSingleEntity(); } }
    public WeatherCostComponent weatherCost { get { return weatherCostEntity.weatherCost; } }
    public bool hasWeatherCost { get { return weatherCostEntity != null; } }

    public GameEntity SetWeatherCost(System.Collections.Generic.Dictionary<Resource, int> newResourcesCost) {
        if(hasWeatherCost) {
            throw new Entitas.EntitasException("Could not set WeatherCost!\n" + this + " already has an entity with WeatherCostComponent!",
                "You should check if the context already has a weatherCostEntity before setting it or use context.ReplaceWeatherCost().");
        }
        var entity = CreateEntity();
        entity.AddWeatherCost(newResourcesCost);
        return entity;
    }

    public void ReplaceWeatherCost(System.Collections.Generic.Dictionary<Resource, int> newResourcesCost) {
        var entity = weatherCostEntity;
        if(entity == null) {
            entity = SetWeatherCost(newResourcesCost);
        } else {
            entity.ReplaceWeatherCost(newResourcesCost);
        }
    }

    public void RemoveWeatherCost() {
        DestroyEntity(weatherCostEntity);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public WeatherCostComponent weatherCost { get { return (WeatherCostComponent)GetComponent(GameComponentsLookup.WeatherCost); } }
    public bool hasWeatherCost { get { return HasComponent(GameComponentsLookup.WeatherCost); } }

    public void AddWeatherCost(System.Collections.Generic.Dictionary<Resource, int> newResourcesCost) {
        var index = GameComponentsLookup.WeatherCost;
        var component = CreateComponent<WeatherCostComponent>(index);
        component.ResourcesCost = newResourcesCost;
        AddComponent(index, component);
    }

    public void ReplaceWeatherCost(System.Collections.Generic.Dictionary<Resource, int> newResourcesCost) {
        var index = GameComponentsLookup.WeatherCost;
        var component = CreateComponent<WeatherCostComponent>(index);
        component.ResourcesCost = newResourcesCost;
        ReplaceComponent(index, component);
    }

    public void RemoveWeatherCost() {
        RemoveComponent(GameComponentsLookup.WeatherCost);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherWeatherCost;

    public static Entitas.IMatcher<GameEntity> WeatherCost {
        get {
            if(_matcherWeatherCost == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WeatherCost);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWeatherCost = matcher;
            }

            return _matcherWeatherCost;
        }
    }
}
