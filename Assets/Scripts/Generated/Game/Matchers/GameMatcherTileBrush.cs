//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public sealed partial class GameMatcher {

    static IMatcher<GameEntity> _matcherTileBrush;

    public static IMatcher<GameEntity> TileBrush {
        get {
            if(_matcherTileBrush == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.TileBrush);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTileBrush = matcher;
            }

            return _matcherTileBrush;
        }
    }
}
