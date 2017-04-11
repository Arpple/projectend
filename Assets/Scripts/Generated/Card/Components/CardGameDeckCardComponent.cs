//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CardEntity {

    static readonly Game.DeckCardComponent gameDeckCardComponent = new Game.DeckCardComponent();

    public bool isGameDeckCard {
        get { return HasComponent(CardComponentsLookup.GameDeckCard); }
        set {
            if(value != isGameDeckCard) {
                if(value) {
                    AddComponent(CardComponentsLookup.GameDeckCard, gameDeckCardComponent);
                } else {
                    RemoveComponent(CardComponentsLookup.GameDeckCard);
                }
            }
        }
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

    static Entitas.IMatcher<CardEntity> _matcherGameDeckCard;

    public static Entitas.IMatcher<CardEntity> GameDeckCard {
        get {
            if(_matcherGameDeckCard == null) {
                var matcher = (Entitas.Matcher<CardEntity>)Entitas.Matcher<CardEntity>.AllOf(CardComponentsLookup.GameDeckCard);
                matcher.componentNames = CardComponentsLookup.componentNames;
                _matcherGameDeckCard = matcher;
            }

            return _matcherGameDeckCard;
        }
    }
}