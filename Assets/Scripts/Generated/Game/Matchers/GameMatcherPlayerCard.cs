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

    static IMatcher<GameEntity> _matcherPlayerCard;

    public static IMatcher<GameEntity> PlayerCard {
        get {
            if(_matcherPlayerCard == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerCard);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerCard = matcher;
            }

            return _matcherPlayerCard;
        }
    }
}
