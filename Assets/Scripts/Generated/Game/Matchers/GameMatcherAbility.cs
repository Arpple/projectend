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

    static IMatcher<GameEntity> _matcherAbility;

    public static IMatcher<GameEntity> Ability {
        get {
            if(_matcherAbility == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.Ability);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAbility = matcher;
            }

            return _matcherAbility;
        }
    }
}
