//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PlayerMissionComponent playerMission { get { return (PlayerMissionComponent)GetComponent(GameComponentsLookup.PlayerMission); } }
    public bool hasPlayerMission { get { return HasComponent(GameComponentsLookup.PlayerMission); } }

    public void AddPlayerMission(PlayerMission newMisisonType) {
        var index = GameComponentsLookup.PlayerMission;
        var component = CreateComponent<PlayerMissionComponent>(index);
        component.MisisonType = newMisisonType;
        AddComponent(index, component);
    }

    public void ReplacePlayerMission(PlayerMission newMisisonType) {
        var index = GameComponentsLookup.PlayerMission;
        var component = CreateComponent<PlayerMissionComponent>(index);
        component.MisisonType = newMisisonType;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerMission() {
        RemoveComponent(GameComponentsLookup.PlayerMission);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPlayerMission;

    public static Entitas.IMatcher<GameEntity> PlayerMission {
        get {
            if(_matcherPlayerMission == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerMission);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerMission = matcher;
            }

            return _matcherPlayerMission;
        }
    }
}
