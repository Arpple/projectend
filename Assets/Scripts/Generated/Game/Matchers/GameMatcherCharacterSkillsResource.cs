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

    static IMatcher<GameEntity> _matcherCharacterSkillsResource;

    public static IMatcher<GameEntity> CharacterSkillsResource {
        get {
            if(_matcherCharacterSkillsResource == null) {
                var matcher = (Matcher<GameEntity>)Matcher<GameEntity>.AllOf(GameComponentsLookup.CharacterSkillsResource);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCharacterSkillsResource = matcher;
            }

            return _matcherCharacterSkillsResource;
        }
    }
}
