//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.RoleComponent gameRole { get { return (Game.RoleComponent)GetComponent(GameComponentsLookup.GameRole); } }
    public bool hasGameRole { get { return HasComponent(GameComponentsLookup.GameRole); } }

    public void AddGameRole(Game.RoleObject newRoleObject) {
        var index = GameComponentsLookup.GameRole;
        var component = CreateComponent<Game.RoleComponent>(index);
        component.RoleObject = newRoleObject;
        AddComponent(index, component);
    }

    public void ReplaceGameRole(Game.RoleObject newRoleObject) {
        var index = GameComponentsLookup.GameRole;
        var component = CreateComponent<Game.RoleComponent>(index);
        component.RoleObject = newRoleObject;
        ReplaceComponent(index, component);
    }

    public void RemoveGameRole() {
        RemoveComponent(GameComponentsLookup.GameRole);
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

    static Entitas.IMatcher<GameEntity> _matcherGameRole;

    public static Entitas.IMatcher<GameEntity> GameRole {
        get {
            if(_matcherGameRole == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameRole);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameRole = matcher;
            }

            return _matcherGameRole;
        }
    }
}
