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

    static IMatcher<GameEntity> _matcherCharacter;

    public static IMatcher<GameEntity> Character {
        get {
            if(_matcherCharacter == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.Character);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCharacter = matcher;
            }

            return _matcherCharacter;
        }
    }
}