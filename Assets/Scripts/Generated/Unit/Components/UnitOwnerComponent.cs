//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    public OwnerComponent owner { get { return (OwnerComponent)GetComponent(UnitComponentsLookup.Owner); } }
    public bool hasOwner { get { return HasComponent(UnitComponentsLookup.Owner); } }

    public void AddOwner(GameEntity newEntity) {
        var index = UnitComponentsLookup.Owner;
        var component = CreateComponent<OwnerComponent>(index);
        component.Entity = newEntity;
        AddComponent(index, component);
    }

    public void ReplaceOwner(GameEntity newEntity) {
        var index = UnitComponentsLookup.Owner;
        var component = CreateComponent<OwnerComponent>(index);
        component.Entity = newEntity;
        ReplaceComponent(index, component);
    }

    public void RemoveOwner() {
        RemoveComponent(UnitComponentsLookup.Owner);
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

    static Entitas.IMatcher<UnitEntity> _matcherOwner;

    public static Entitas.IMatcher<UnitEntity> Owner {
        get {
            if(_matcherOwner == null) {
                var matcher = (Entitas.Matcher<UnitEntity>)Entitas.Matcher<UnitEntity>.AllOf(UnitComponentsLookup.Owner);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherOwner = matcher;
            }

            return _matcherOwner;
        }
    }
}
