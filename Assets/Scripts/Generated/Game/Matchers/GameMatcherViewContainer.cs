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

    static IMatcher<GameEntity> _matcherViewContainer;

    public static IMatcher<GameEntity> ViewContainer {
        get {
            if(_matcherViewContainer == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.ViewContainer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherViewContainer = matcher;
            }

            return _matcherViewContainer;
        }
    }
}
