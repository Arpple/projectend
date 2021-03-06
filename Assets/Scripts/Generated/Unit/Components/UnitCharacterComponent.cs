//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    public CharacterComponent character { get { return (CharacterComponent)GetComponent(UnitComponentsLookup.Character); } }
    public bool hasCharacter { get { return HasComponent(UnitComponentsLookup.Character); } }

    public void AddCharacter(Character newType) {
        var index = UnitComponentsLookup.Character;
        var component = CreateComponent<CharacterComponent>(index);
        component.Type = newType;
        AddComponent(index, component);
    }

    public void ReplaceCharacter(Character newType) {
        var index = UnitComponentsLookup.Character;
        var component = CreateComponent<CharacterComponent>(index);
        component.Type = newType;
        ReplaceComponent(index, component);
    }

    public void RemoveCharacter() {
        RemoveComponent(UnitComponentsLookup.Character);
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

    static Entitas.IMatcher<UnitEntity> _matcherCharacter;

    public static Entitas.IMatcher<UnitEntity> Character {
        get {
            if(_matcherCharacter == null) {
                var matcher = (Entitas.Matcher<UnitEntity>)Entitas.Matcher<UnitEntity>.AllOf(UnitComponentsLookup.Character);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherCharacter = matcher;
            }

            return _matcherCharacter;
        }
    }
}
