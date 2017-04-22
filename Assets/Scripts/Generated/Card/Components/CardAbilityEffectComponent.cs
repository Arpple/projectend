//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CardEntity {

    public AbilityEffectComponent abilityEffect { get { return (AbilityEffectComponent)GetComponent(CardComponentsLookup.AbilityEffect); } }
    public bool hasAbilityEffect { get { return HasComponent(CardComponentsLookup.AbilityEffect); } }

    public void AddAbilityEffect(AbilityEffect newEffectObject) {
        var index = CardComponentsLookup.AbilityEffect;
        var component = CreateComponent<AbilityEffectComponent>(index);
        component.EffectObject = newEffectObject;
        AddComponent(index, component);
    }

    public void ReplaceAbilityEffect(AbilityEffect newEffectObject) {
        var index = CardComponentsLookup.AbilityEffect;
        var component = CreateComponent<AbilityEffectComponent>(index);
        component.EffectObject = newEffectObject;
        ReplaceComponent(index, component);
    }

    public void RemoveAbilityEffect() {
        RemoveComponent(CardComponentsLookup.AbilityEffect);
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
public sealed partial class CardMatcher {

    static Entitas.IMatcher<CardEntity> _matcherAbilityEffect;

    public static Entitas.IMatcher<CardEntity> AbilityEffect {
        get {
            if(_matcherAbilityEffect == null) {
                var matcher = (Entitas.Matcher<CardEntity>)Entitas.Matcher<CardEntity>.AllOf(CardComponentsLookup.AbilityEffect);
                matcher.componentNames = CardComponentsLookup.componentNames;
                _matcherAbilityEffect = matcher;
            }

            return _matcherAbilityEffect;
        }
    }
}