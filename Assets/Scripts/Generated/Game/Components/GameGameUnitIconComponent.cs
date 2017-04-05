//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.UnitIconComponent gameUnitIcon { get { return (Game.UnitIconComponent)GetComponent(GameComponentsLookup.GameUnitIcon); } }
    public bool hasGameUnitIcon { get { return HasComponent(GameComponentsLookup.GameUnitIcon); } }

    public void AddGameUnitIcon(UnityEngine.Sprite newIconSprite) {
        var index = GameComponentsLookup.GameUnitIcon;
        var component = CreateComponent<Game.UnitIconComponent>(index);
        component.IconSprite = newIconSprite;
        AddComponent(index, component);
    }

    public void ReplaceGameUnitIcon(UnityEngine.Sprite newIconSprite) {
        var index = GameComponentsLookup.GameUnitIcon;
        var component = CreateComponent<Game.UnitIconComponent>(index);
        component.IconSprite = newIconSprite;
        ReplaceComponent(index, component);
    }

    public void RemoveGameUnitIcon() {
        RemoveComponent(GameComponentsLookup.GameUnitIcon);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameUnitIcon;

    public static Entitas.IMatcher<GameEntity> GameUnitIcon {
        get {
            if(_matcherGameUnitIcon == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameUnitIcon);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameUnitIcon = matcher;
            }

            return _matcherGameUnitIcon;
        }
    }
}