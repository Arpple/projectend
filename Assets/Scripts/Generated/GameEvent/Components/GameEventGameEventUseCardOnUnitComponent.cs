//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEventEntity {

    public Game.EventUseCardOnUnit gameEventUseCardOnUnit { get { return (Game.EventUseCardOnUnit)GetComponent(GameEventComponentsLookup.GameEventUseCardOnUnit); } }
    public bool hasGameEventUseCardOnUnit { get { return HasComponent(GameEventComponentsLookup.GameEventUseCardOnUnit); } }

    public void AddGameEventUseCardOnUnit(GameEntity newUserEntity, GameEntity newCardEnttiy, GameEntity newTargetEnttiy) {
        var index = GameEventComponentsLookup.GameEventUseCardOnUnit;
        var component = CreateComponent<Game.EventUseCardOnUnit>(index);
        component.UserEntity = newUserEntity;
        component.CardEnttiy = newCardEnttiy;
        component.TargetEnttiy = newTargetEnttiy;
        AddComponent(index, component);
    }

    public void ReplaceGameEventUseCardOnUnit(GameEntity newUserEntity, GameEntity newCardEnttiy, GameEntity newTargetEnttiy) {
        var index = GameEventComponentsLookup.GameEventUseCardOnUnit;
        var component = CreateComponent<Game.EventUseCardOnUnit>(index);
        component.UserEntity = newUserEntity;
        component.CardEnttiy = newCardEnttiy;
        component.TargetEnttiy = newTargetEnttiy;
        ReplaceComponent(index, component);
    }

    public void RemoveGameEventUseCardOnUnit() {
        RemoveComponent(GameEventComponentsLookup.GameEventUseCardOnUnit);
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
public sealed partial class GameEventMatcher {

    static Entitas.IMatcher<GameEventEntity> _matcherGameEventUseCardOnUnit;

    public static Entitas.IMatcher<GameEventEntity> GameEventUseCardOnUnit {
        get {
            if(_matcherGameEventUseCardOnUnit == null) {
                var matcher = (Entitas.Matcher<GameEventEntity>)Entitas.Matcher<GameEventEntity>.AllOf(GameEventComponentsLookup.GameEventUseCardOnUnit);
                matcher.componentNames = GameEventComponentsLookup.componentNames;
                _matcherGameEventUseCardOnUnit = matcher;
            }

            return _matcherGameEventUseCardOnUnit;
        }
    }
}
