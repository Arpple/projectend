//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PlayerDeckComponent playerDeck { get { return (PlayerDeckComponent)GetComponent(GameComponentsLookup.PlayerDeck); } }
    public bool hasPlayerDeck { get { return HasComponent(GameComponentsLookup.PlayerDeck); } }

    public void AddPlayerDeck(CardContainer newPlayerDeckObject) {
        var index = GameComponentsLookup.PlayerDeck;
        var component = CreateComponent<PlayerDeckComponent>(index);
        component.PlayerDeckObject = newPlayerDeckObject;
        AddComponent(index, component);
    }

    public void ReplacePlayerDeck(CardContainer newPlayerDeckObject) {
        var index = GameComponentsLookup.PlayerDeck;
        var component = CreateComponent<PlayerDeckComponent>(index);
        component.PlayerDeckObject = newPlayerDeckObject;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerDeck() {
        RemoveComponent(GameComponentsLookup.PlayerDeck);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayerDeck;

    public static Entitas.IMatcher<GameEntity> PlayerDeck {
        get {
            if(_matcherPlayerDeck == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerDeck);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerDeck = matcher;
            }

            return _matcherPlayerDeck;
        }
    }
}
