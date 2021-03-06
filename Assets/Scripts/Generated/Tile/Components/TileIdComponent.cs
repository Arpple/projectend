//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TileEntity {

    public IdComponent id { get { return (IdComponent)GetComponent(TileComponentsLookup.Id); } }
    public bool hasId { get { return HasComponent(TileComponentsLookup.Id); } }

    public void AddId(int newId) {
        var index = TileComponentsLookup.Id;
        var component = CreateComponent<IdComponent>(index);
        component.Id = newId;
        AddComponent(index, component);
    }

    public void ReplaceId(int newId) {
        var index = TileComponentsLookup.Id;
        var component = CreateComponent<IdComponent>(index);
        component.Id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveId() {
        RemoveComponent(TileComponentsLookup.Id);
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
public sealed partial class TileMatcher {

    static Entitas.IMatcher<TileEntity> _matcherId;

    public static Entitas.IMatcher<TileEntity> Id {
        get {
            if(_matcherId == null) {
                var matcher = (Entitas.Matcher<TileEntity>)Entitas.Matcher<TileEntity>.AllOf(TileComponentsLookup.Id);
                matcher.componentNames = TileComponentsLookup.componentNames;
                _matcherId = matcher;
            }

            return _matcherId;
        }
    }
}
