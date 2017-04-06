//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CardEntity {

    public Game.AbilityResourcesComponent gameAbilityResources { get { return (Game.AbilityResourcesComponent)GetComponent(CardComponentsLookup.GameAbilityResources); } }
    public bool hasGameAbilityResources { get { return HasComponent(CardComponentsLookup.GameAbilityResources); } }

    public void AddGameAbilityResources(string newAbilityClassName) {
        var index = CardComponentsLookup.GameAbilityResources;
        var component = CreateComponent<Game.AbilityResourcesComponent>(index);
        component.AbilityClassName = newAbilityClassName;
        AddComponent(index, component);
    }

    public void ReplaceGameAbilityResources(string newAbilityClassName) {
        var index = CardComponentsLookup.GameAbilityResources;
        var component = CreateComponent<Game.AbilityResourcesComponent>(index);
        component.AbilityClassName = newAbilityClassName;
        ReplaceComponent(index, component);
    }

    public void RemoveGameAbilityResources() {
        RemoveComponent(CardComponentsLookup.GameAbilityResources);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class CardMatcher {

    static Entitas.IMatcher<CardEntity> _matcherGameAbilityResources;

    public static Entitas.IMatcher<CardEntity> GameAbilityResources {
        get {
            if(_matcherGameAbilityResources == null) {
                var matcher = (Entitas.Matcher<CardEntity>)Entitas.Matcher<CardEntity>.AllOf(CardComponentsLookup.GameAbilityResources);
                matcher.componentNames = CardComponentsLookup.componentNames;
                _matcherGameAbilityResources = matcher;
            }

            return _matcherGameAbilityResources;
        }
    }
}
