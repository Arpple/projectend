//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity weatherEntity { get { return GetGroup(GameMatcher.Weather).GetSingleEntity(); } }
    public WeatherComponent weather { get { return weatherEntity.weather; } }
    public bool hasWeather { get { return weatherEntity != null; } }

    public GameEntity SetWeather(Weather newType) {
        if(hasWeather) {
            throw new Entitas.EntitasException("Could not set Weather!\n" + this + " already has an entity with WeatherComponent!",
                "You should check if the context already has a weatherEntity before setting it or use context.ReplaceWeather().");
        }
        var entity = CreateEntity();
        entity.AddWeather(newType);
        return entity;
    }

    public void ReplaceWeather(Weather newType) {
        var entity = weatherEntity;
        if(entity == null) {
            entity = SetWeather(newType);
        } else {
            entity.ReplaceWeather(newType);
        }
    }

    public void RemoveWeather() {
        DestroyEntity(weatherEntity);
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

    public WeatherComponent weather { get { return (WeatherComponent)GetComponent(GameComponentsLookup.Weather); } }
    public bool hasWeather { get { return HasComponent(GameComponentsLookup.Weather); } }

    public void AddWeather(Weather newType) {
        var index = GameComponentsLookup.Weather;
        var component = CreateComponent<WeatherComponent>(index);
        component.Type = newType;
        AddComponent(index, component);
    }

    public void ReplaceWeather(Weather newType) {
        var index = GameComponentsLookup.Weather;
        var component = CreateComponent<WeatherComponent>(index);
        component.Type = newType;
        ReplaceComponent(index, component);
    }

    public void RemoveWeather() {
        RemoveComponent(GameComponentsLookup.Weather);
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

    static Entitas.IMatcher<GameEntity> _matcherWeather;

    public static Entitas.IMatcher<GameEntity> Weather {
        get {
            if(_matcherWeather == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Weather);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWeather = matcher;
            }

            return _matcherWeather;
        }
    }
}
