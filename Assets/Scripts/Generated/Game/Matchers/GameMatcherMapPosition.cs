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

    static IMatcher<GameEntity> _matcherMapPosition;

    public static IMatcher<GameEntity> MapPosition {
        get {
            if(_matcherMapPosition == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.MapPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMapPosition = matcher;
            }

            return _matcherMapPosition;
        }
    }
}
