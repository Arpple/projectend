//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Game.WinnerComponent gameWinnerComponent = new Game.WinnerComponent();

    public bool isGameWinner {
        get { return HasComponent(GameComponentsLookup.GameWinner); }
        set {
            if(value != isGameWinner) {
                if(value) {
                    AddComponent(GameComponentsLookup.GameWinner, gameWinnerComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.GameWinner);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherGameWinner;

    public static Entitas.IMatcher<GameEntity> GameWinner {
        get {
            if(_matcherGameWinner == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameWinner);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameWinner = matcher;
            }

            return _matcherGameWinner;
        }
    }
}