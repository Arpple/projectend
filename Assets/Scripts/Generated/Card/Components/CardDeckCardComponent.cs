//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CardEntity {

    public DeckCardComponent deckCard { get { return (DeckCardComponent)GetComponent(CardComponentsLookup.DeckCard); } }
    public bool hasDeckCard { get { return HasComponent(CardComponentsLookup.DeckCard); } }

    public void AddDeckCard(DeckCard newType) {
        var index = CardComponentsLookup.DeckCard;
        var component = CreateComponent<DeckCardComponent>(index);
        component.Type = newType;
        AddComponent(index, component);
    }

    public void ReplaceDeckCard(DeckCard newType) {
        var index = CardComponentsLookup.DeckCard;
        var component = CreateComponent<DeckCardComponent>(index);
        component.Type = newType;
        ReplaceComponent(index, component);
    }

    public void RemoveDeckCard() {
        RemoveComponent(CardComponentsLookup.DeckCard);
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

    static Entitas.IMatcher<CardEntity> _matcherDeckCard;

    public static Entitas.IMatcher<CardEntity> DeckCard {
        get {
            if(_matcherDeckCard == null) {
                var matcher = (Entitas.Matcher<CardEntity>)Entitas.Matcher<CardEntity>.AllOf(CardComponentsLookup.DeckCard);
                matcher.componentNames = CardComponentsLookup.componentNames;
                _matcherDeckCard = matcher;
            }

            return _matcherDeckCard;
        }
    }
}
