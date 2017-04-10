//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    public Game.UnitIconResourceComponent gameUnitIconResource { get { return (Game.UnitIconResourceComponent)GetComponent(UnitComponentsLookup.GameUnitIconResource); } }
    public bool hasGameUnitIconResource { get { return HasComponent(UnitComponentsLookup.GameUnitIconResource); } }

    public void AddGameUnitIconResource(string newIconSpritePath) {
        var index = UnitComponentsLookup.GameUnitIconResource;
        var component = CreateComponent<Game.UnitIconResourceComponent>(index);
        component.IconSpritePath = newIconSpritePath;
        AddComponent(index, component);
    }

    public void ReplaceGameUnitIconResource(string newIconSpritePath) {
        var index = UnitComponentsLookup.GameUnitIconResource;
        var component = CreateComponent<Game.UnitIconResourceComponent>(index);
        component.IconSpritePath = newIconSpritePath;
        ReplaceComponent(index, component);
    }

    public void RemoveGameUnitIconResource() {
        RemoveComponent(UnitComponentsLookup.GameUnitIconResource);
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

    static Entitas.IMatcher<UnitEntity> _matcherGameUnitIconResource;

    public static Entitas.IMatcher<UnitEntity> GameUnitIconResource {
        get {
            if(_matcherGameUnitIconResource == null) {
                var matcher = (Entitas.Matcher<UnitEntity>)Entitas.Matcher<UnitEntity>.AllOf(UnitComponentsLookup.GameUnitIconResource);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherGameUnitIconResource = matcher;
            }

            return _matcherGameUnitIconResource;
        }
    }
}
