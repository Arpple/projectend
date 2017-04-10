//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TileEntity {

    public Game.MapPositionComponent gameMapPosition { get { return (Game.MapPositionComponent)GetComponent(TileComponentsLookup.GameMapPosition); } }
    public bool hasGameMapPosition { get { return HasComponent(TileComponentsLookup.GameMapPosition); } }

    public void AddGameMapPosition(Position newValue) {
        var index = TileComponentsLookup.GameMapPosition;
        var component = CreateComponent<Game.MapPositionComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameMapPosition(Position newValue) {
        var index = TileComponentsLookup.GameMapPosition;
        var component = CreateComponent<Game.MapPositionComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameMapPosition() {
        RemoveComponent(TileComponentsLookup.GameMapPosition);
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

    static Entitas.IMatcher<TileEntity> _matcherGameMapPosition;

    public static Entitas.IMatcher<TileEntity> GameMapPosition {
        get {
            if(_matcherGameMapPosition == null) {
                var matcher = (Entitas.Matcher<TileEntity>)Entitas.Matcher<TileEntity>.AllOf(TileComponentsLookup.GameMapPosition);
                matcher.componentNames = TileComponentsLookup.componentNames;
                _matcherGameMapPosition = matcher;
            }

            return _matcherGameMapPosition;
        }
    }
}
