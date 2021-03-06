//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly WinnerComponent winnerComponent = new WinnerComponent();

    public bool isWinner {
        get { return HasComponent(GameComponentsLookup.Winner); }
        set {
            if(value != isWinner) {
                if(value) {
                    AddComponent(GameComponentsLookup.Winner, winnerComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.Winner);
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

    static Entitas.IMatcher<GameEntity> _matcherWinner;

    public static Entitas.IMatcher<GameEntity> Winner {
        get {
            if(_matcherWinner == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Winner);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWinner = matcher;
            }

            return _matcherWinner;
        }
    }
}
