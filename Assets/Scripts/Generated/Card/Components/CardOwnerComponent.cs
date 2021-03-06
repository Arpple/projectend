//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CardEntity {

    public OwnerComponent owner { get { return (OwnerComponent)GetComponent(CardComponentsLookup.Owner); } }
    public bool hasOwner { get { return HasComponent(CardComponentsLookup.Owner); } }

    public void AddOwner(GameEntity newEntity) {
        var index = CardComponentsLookup.Owner;
        var component = CreateComponent<OwnerComponent>(index);
        component.Entity = newEntity;
        AddComponent(index, component);
    }

    public void ReplaceOwner(GameEntity newEntity) {
        var index = CardComponentsLookup.Owner;
        var component = CreateComponent<OwnerComponent>(index);
        component.Entity = newEntity;
        ReplaceComponent(index, component);
    }

    public void RemoveOwner() {
        RemoveComponent(CardComponentsLookup.Owner);
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

    static Entitas.IMatcher<CardEntity> _matcherOwner;

    public static Entitas.IMatcher<CardEntity> Owner {
        get {
            if(_matcherOwner == null) {
                var matcher = (Entitas.Matcher<CardEntity>)Entitas.Matcher<CardEntity>.AllOf(CardComponentsLookup.Owner);
                matcher.componentNames = CardComponentsLookup.componentNames;
                _matcherOwner = matcher;
            }

            return _matcherOwner;
        }
    }
}
