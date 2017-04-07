//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CardEntity {

    public Game.IdComponent gameId { get { return (Game.IdComponent)GetComponent(CardComponentsLookup.GameId); } }
    public bool hasGameId { get { return HasComponent(CardComponentsLookup.GameId); } }

    public void AddGameId(int newId) {
        var index = CardComponentsLookup.GameId;
        var component = CreateComponent<Game.IdComponent>(index);
        component.Id = newId;
        AddComponent(index, component);
    }

    public void ReplaceGameId(int newId) {
        var index = CardComponentsLookup.GameId;
        var component = CreateComponent<Game.IdComponent>(index);
        component.Id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveGameId() {
        RemoveComponent(CardComponentsLookup.GameId);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CardMatcher {

    static Entitas.IMatcher<CardEntity> _matcherGameId;

    public static Entitas.IMatcher<CardEntity> GameId {
        get {
            if(_matcherGameId == null) {
                var matcher = (Entitas.Matcher<CardEntity>)Entitas.Matcher<CardEntity>.AllOf(CardComponentsLookup.GameId);
                matcher.componentNames = CardComponentsLookup.componentNames;
                _matcherGameId = matcher;
            }

            return _matcherGameId;
        }
    }
}
