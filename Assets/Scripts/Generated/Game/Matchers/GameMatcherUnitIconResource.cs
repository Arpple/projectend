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

    static IMatcher<GameEntity> _matcherUnitIconResource;

    public static IMatcher<GameEntity> UnitIconResource {
        get {
            if(_matcherUnitIconResource == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.UnitIconResource);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUnitIconResource = matcher;
            }

            return _matcherUnitIconResource;
        }
    }
}