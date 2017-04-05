//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.PlayerBoxComponent gamePlayerBox { get { return (Game.PlayerBoxComponent)GetComponent(GameComponentsLookup.GamePlayerBox); } }
    public bool hasGamePlayerBox { get { return HasComponent(GameComponentsLookup.GamePlayerBox); } }

    public void AddGamePlayerBox(Game.UI.PlayerBox newBoxObject) {
        var index = GameComponentsLookup.GamePlayerBox;
        var component = CreateComponent<Game.PlayerBoxComponent>(index);
        component.BoxObject = newBoxObject;
        AddComponent(index, component);
    }

    public void ReplaceGamePlayerBox(Game.UI.PlayerBox newBoxObject) {
        var index = GameComponentsLookup.GamePlayerBox;
        var component = CreateComponent<Game.PlayerBoxComponent>(index);
        component.BoxObject = newBoxObject;
        ReplaceComponent(index, component);
    }

    public void RemoveGamePlayerBox() {
        RemoveComponent(GameComponentsLookup.GamePlayerBox);
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

    static Entitas.IMatcher<GameEntity> _matcherGamePlayerBox;

    public static Entitas.IMatcher<GameEntity> GamePlayerBox {
        get {
            if(_matcherGamePlayerBox == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GamePlayerBox);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGamePlayerBox = matcher;
            }

            return _matcherGamePlayerBox;
        }
    }
}