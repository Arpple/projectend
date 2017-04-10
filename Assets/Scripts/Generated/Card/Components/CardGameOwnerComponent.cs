//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CardEntity {

    public Game.OwnerComponent gameOwner { get { return (Game.OwnerComponent)GetComponent(CardComponentsLookup.GameOwner); } }
    public bool hasGameOwner { get { return HasComponent(CardComponentsLookup.GameOwner); } }

    public void AddGameOwner(GameEntity newEntity) {
        var index = CardComponentsLookup.GameOwner;
        var component = CreateComponent<Game.OwnerComponent>(index);
        component.Entity = newEntity;
        AddComponent(index, component);
    }

    public void ReplaceGameOwner(GameEntity newEntity) {
        var index = CardComponentsLookup.GameOwner;
        var component = CreateComponent<Game.OwnerComponent>(index);
        component.Entity = newEntity;
        ReplaceComponent(index, component);
    }

    public void RemoveGameOwner() {
        RemoveComponent(CardComponentsLookup.GameOwner);
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

    static Entitas.IMatcher<CardEntity> _matcherGameOwner;

    public static Entitas.IMatcher<CardEntity> GameOwner {
        get {
            if(_matcherGameOwner == null) {
                var matcher = (Entitas.Matcher<CardEntity>)Entitas.Matcher<CardEntity>.AllOf(CardComponentsLookup.GameOwner);
                matcher.componentNames = CardComponentsLookup.componentNames;
                _matcherGameOwner = matcher;
            }

            return _matcherGameOwner;
        }
    }
}
