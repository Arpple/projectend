//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CardEntity {

    public ResourceCardComponent resourceCard { get { return (ResourceCardComponent)GetComponent(CardComponentsLookup.ResourceCard); } }
    public bool hasResourceCard { get { return HasComponent(CardComponentsLookup.ResourceCard); } }

    public void AddResourceCard(Resource newType) {
        var index = CardComponentsLookup.ResourceCard;
        var component = CreateComponent<ResourceCardComponent>(index);
        component.Type = newType;
        AddComponent(index, component);
    }

    public void ReplaceResourceCard(Resource newType) {
        var index = CardComponentsLookup.ResourceCard;
        var component = CreateComponent<ResourceCardComponent>(index);
        component.Type = newType;
        ReplaceComponent(index, component);
    }

    public void RemoveResourceCard() {
        RemoveComponent(CardComponentsLookup.ResourceCard);
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

    static Entitas.IMatcher<CardEntity> _matcherResourceCard;

    public static Entitas.IMatcher<CardEntity> ResourceCard {
        get {
            if(_matcherResourceCard == null) {
                var matcher = (Entitas.Matcher<CardEntity>)Entitas.Matcher<CardEntity>.AllOf(CardComponentsLookup.ResourceCard);
                matcher.componentNames = CardComponentsLookup.componentNames;
                _matcherResourceCard = matcher;
            }

            return _matcherResourceCard;
        }
    }
}
