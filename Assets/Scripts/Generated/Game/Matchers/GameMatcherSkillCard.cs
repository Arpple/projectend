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

    static IMatcher<GameEntity> _matcherSkillCard;

    public static IMatcher<GameEntity> SkillCard {
        get {
            if(_matcherSkillCard == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.SkillCard);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSkillCard = matcher;
            }

            return _matcherSkillCard;
        }
    }
}