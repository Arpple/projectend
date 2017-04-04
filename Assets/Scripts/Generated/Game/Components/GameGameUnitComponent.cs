//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.UnitComponent gameUnit { get { return (Game.UnitComponent)GetComponent(GameComponentsLookup.GameUnit); } }
    public bool hasGameUnit { get { return HasComponent(GameComponentsLookup.GameUnit); } }

    public void AddGameUnit(int newId, GameEntity newOwnerEntity) {
        var index = GameComponentsLookup.GameUnit;
        var component = CreateComponent<Game.UnitComponent>(index);
        component.Id = newId;
        component.OwnerEntity = newOwnerEntity;
        AddComponent(index, component);
    }

    public void ReplaceGameUnit(int newId, GameEntity newOwnerEntity) {
        var index = GameComponentsLookup.GameUnit;
        var component = CreateComponent<Game.UnitComponent>(index);
        component.Id = newId;
        component.OwnerEntity = newOwnerEntity;
        ReplaceComponent(index, component);
    }

    public void RemoveGameUnit() {
        RemoveComponent(GameComponentsLookup.GameUnit);
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

    static Entitas.IMatcher<GameEntity> _matcherGameUnit;

    public static Entitas.IMatcher<GameEntity> GameUnit {
        get {
            if(_matcherGameUnit == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameUnit);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameUnit = matcher;
            }

            return _matcherGameUnit;
        }
    }
}
