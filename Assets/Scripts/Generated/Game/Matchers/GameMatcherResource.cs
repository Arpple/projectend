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

    static IMatcher<GameEntity> _matcherResource;

    public static IMatcher<GameEntity> Resource {
        get {
            if(_matcherResource == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.Resource);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherResource = matcher;
            }

            return _matcherResource;
        }
    }
}
