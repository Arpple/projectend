//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    public Game.IdComponent gameId { get { return (Game.IdComponent)GetComponent(UnitComponentsLookup.GameId); } }
    public bool hasGameId { get { return HasComponent(UnitComponentsLookup.GameId); } }

    public void AddGameId(int newId) {
        var index = UnitComponentsLookup.GameId;
        var component = CreateComponent<Game.IdComponent>(index);
        component.Id = newId;
        AddComponent(index, component);
    }

    public void ReplaceGameId(int newId) {
        var index = UnitComponentsLookup.GameId;
        var component = CreateComponent<Game.IdComponent>(index);
        component.Id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveGameId() {
        RemoveComponent(UnitComponentsLookup.GameId);
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
public sealed partial class UnitMatcher {

    static Entitas.IMatcher<UnitEntity> _matcherGameId;

    public static Entitas.IMatcher<UnitEntity> GameId {
        get {
            if(_matcherGameId == null) {
                var matcher = (Entitas.Matcher<UnitEntity>)Entitas.Matcher<UnitEntity>.AllOf(UnitComponentsLookup.GameId);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherGameId = matcher;
            }

            return _matcherGameId;
        }
    }
}
