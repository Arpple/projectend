//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.IdComponent gameId { get { return (Game.IdComponent)GetComponent(GameComponentsLookup.GameId); } }
    public bool hasGameId { get { return HasComponent(GameComponentsLookup.GameId); } }

    public void AddGameId(int newId) {
        var index = GameComponentsLookup.GameId;
        var component = CreateComponent<Game.IdComponent>(index);
        component.Id = newId;
        AddComponent(index, component);
    }

    public void ReplaceGameId(int newId) {
        var index = GameComponentsLookup.GameId;
        var component = CreateComponent<Game.IdComponent>(index);
        component.Id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveGameId() {
        RemoveComponent(GameComponentsLookup.GameId);
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

    static Entitas.IMatcher<GameEntity> _matcherGameId;

    public static Entitas.IMatcher<GameEntity> GameId {
        get {
            if(_matcherGameId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameId = matcher;
            }

            return _matcherGameId;
        }
    }
}