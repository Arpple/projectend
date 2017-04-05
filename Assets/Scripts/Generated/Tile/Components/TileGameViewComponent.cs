//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class TileEntity {

    public Game.ViewComponent gameView { get { return (Game.ViewComponent)GetComponent(TileComponentsLookup.GameView); } }
    public bool hasGameView { get { return HasComponent(TileComponentsLookup.GameView); } }

    public void AddGameView(UnityEngine.GameObject newGameObject) {
        var index = TileComponentsLookup.GameView;
        var component = CreateComponent<Game.ViewComponent>(index);
        component.GameObject = newGameObject;
        AddComponent(index, component);
    }

    public void ReplaceGameView(UnityEngine.GameObject newGameObject) {
        var index = TileComponentsLookup.GameView;
        var component = CreateComponent<Game.ViewComponent>(index);
        component.GameObject = newGameObject;
        ReplaceComponent(index, component);
    }

    public void RemoveGameView() {
        RemoveComponent(TileComponentsLookup.GameView);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.MatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class TileMatcher {

    static Entitas.IMatcher<TileEntity> _matcherGameView;

    public static Entitas.IMatcher<TileEntity> GameView {
        get {
            if(_matcherGameView == null) {
                var matcher = (Entitas.Matcher<TileEntity>)Entitas.Matcher<TileEntity>.AllOf(TileComponentsLookup.GameView);
                matcher.componentNames = TileComponentsLookup.componentNames;
                _matcherGameView = matcher;
            }

            return _matcherGameView;
        }
    }
}
