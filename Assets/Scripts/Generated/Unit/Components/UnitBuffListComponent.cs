//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    public BuffListComponent buffList { get { return (BuffListComponent)GetComponent(UnitComponentsLookup.BuffList); } }
    public bool hasBuffList { get { return HasComponent(UnitComponentsLookup.BuffList); } }

    public void AddBuffList(System.Collections.Generic.List<BuffEntity> newList) {
        var index = UnitComponentsLookup.BuffList;
        var component = CreateComponent<BuffListComponent>(index);
        component.List = newList;
        AddComponent(index, component);
    }

    public void ReplaceBuffList(System.Collections.Generic.List<BuffEntity> newList) {
        var index = UnitComponentsLookup.BuffList;
        var component = CreateComponent<BuffListComponent>(index);
        component.List = newList;
        ReplaceComponent(index, component);
    }

    public void RemoveBuffList() {
        RemoveComponent(UnitComponentsLookup.BuffList);
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

    static Entitas.IMatcher<UnitEntity> _matcherBuffList;

    public static Entitas.IMatcher<UnitEntity> BuffList {
        get {
            if(_matcherBuffList == null) {
                var matcher = (Entitas.Matcher<UnitEntity>)Entitas.Matcher<UnitEntity>.AllOf(UnitComponentsLookup.BuffList);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherBuffList = matcher;
            }

            return _matcherBuffList;
        }
    }
}