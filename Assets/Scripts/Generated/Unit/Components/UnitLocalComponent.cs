//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitContext {

    public UnitEntity localEntity { get { return GetGroup(UnitMatcher.Local).GetSingleEntity(); } }

    public bool isLocal {
        get { return localEntity != null; }
        set {
            var entity = localEntity;
            if(value != (entity != null)) {
                if(value) {
                    CreateEntity().isLocal = true;
                } else {
                    DestroyEntity(entity);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    static readonly LocalComponent localComponent = new LocalComponent();

    public bool isLocal {
        get { return HasComponent(UnitComponentsLookup.Local); }
        set {
            if(value != isLocal) {
                if(value) {
                    AddComponent(UnitComponentsLookup.Local, localComponent);
                } else {
                    RemoveComponent(UnitComponentsLookup.Local);
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
public sealed partial class UnitMatcher {

    static Entitas.IMatcher<UnitEntity> _matcherLocal;

    public static Entitas.IMatcher<UnitEntity> Local {
        get {
            if(_matcherLocal == null) {
                var matcher = (Entitas.Matcher<UnitEntity>)Entitas.Matcher<UnitEntity>.AllOf(UnitComponentsLookup.Local);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherLocal = matcher;
            }

            return _matcherLocal;
        }
    }
}