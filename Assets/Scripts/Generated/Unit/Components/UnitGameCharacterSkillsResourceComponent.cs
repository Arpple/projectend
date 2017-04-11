//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    public Game.CharacterSkillsResourceComponent gameCharacterSkillsResource { get { return (Game.CharacterSkillsResourceComponent)GetComponent(UnitComponentsLookup.GameCharacterSkillsResource); } }
    public bool hasGameCharacterSkillsResource { get { return HasComponent(UnitComponentsLookup.GameCharacterSkillsResource); } }

    public void AddGameCharacterSkillsResource(System.Collections.Generic.List<Game.Card> newSkills) {
        var index = UnitComponentsLookup.GameCharacterSkillsResource;
        var component = CreateComponent<Game.CharacterSkillsResourceComponent>(index);
        component.Skills = newSkills;
        AddComponent(index, component);
    }

    public void ReplaceGameCharacterSkillsResource(System.Collections.Generic.List<Game.Card> newSkills) {
        var index = UnitComponentsLookup.GameCharacterSkillsResource;
        var component = CreateComponent<Game.CharacterSkillsResourceComponent>(index);
        component.Skills = newSkills;
        ReplaceComponent(index, component);
    }

    public void RemoveGameCharacterSkillsResource() {
        RemoveComponent(UnitComponentsLookup.GameCharacterSkillsResource);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class UnitMatcher {

    static Entitas.IMatcher<UnitEntity> _matcherGameCharacterSkillsResource;

    public static Entitas.IMatcher<UnitEntity> GameCharacterSkillsResource {
        get {
            if(_matcherGameCharacterSkillsResource == null) {
                var matcher = (Entitas.Matcher<UnitEntity>)Entitas.Matcher<UnitEntity>.AllOf(UnitComponentsLookup.GameCharacterSkillsResource);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherGameCharacterSkillsResource = matcher;
            }

            return _matcherGameCharacterSkillsResource;
        }
    }
}