//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.UnitDetailComponent gameUnitDetail { get { return (Game.UnitDetailComponent)GetComponent(GameComponentsLookup.GameUnitDetail); } }
    public bool hasGameUnitDetail { get { return HasComponent(GameComponentsLookup.GameUnitDetail); } }

    public void AddGameUnitDetail(string newName, string newDescription) {
        var index = GameComponentsLookup.GameUnitDetail;
        var component = CreateComponent<Game.UnitDetailComponent>(index);
        component.Name = newName;
        component.Description = newDescription;
        AddComponent(index, component);
    }

    public void ReplaceGameUnitDetail(string newName, string newDescription) {
        var index = GameComponentsLookup.GameUnitDetail;
        var component = CreateComponent<Game.UnitDetailComponent>(index);
        component.Name = newName;
        component.Description = newDescription;
        ReplaceComponent(index, component);
    }

    public void RemoveGameUnitDetail() {
        RemoveComponent(GameComponentsLookup.GameUnitDetail);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameUnitDetail;

    public static Entitas.IMatcher<GameEntity> GameUnitDetail {
        get {
            if(_matcherGameUnitDetail == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameUnitDetail);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameUnitDetail = matcher;
            }

            return _matcherGameUnitDetail;
        }
    }
}
