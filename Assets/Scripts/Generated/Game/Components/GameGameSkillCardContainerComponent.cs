//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.SkillCardContainerComponent gameSkillCardContainer { get { return (Game.SkillCardContainerComponent)GetComponent(GameComponentsLookup.GameSkillCardContainer); } }
    public bool hasGameSkillCardContainer { get { return HasComponent(GameComponentsLookup.GameSkillCardContainer); } }

    public void AddGameSkillCardContainer(Game.UI.CardContainer newContainerObject) {
        var index = GameComponentsLookup.GameSkillCardContainer;
        var component = CreateComponent<Game.SkillCardContainerComponent>(index);
        component.ContainerObject = newContainerObject;
        AddComponent(index, component);
    }

    public void ReplaceGameSkillCardContainer(Game.UI.CardContainer newContainerObject) {
        var index = GameComponentsLookup.GameSkillCardContainer;
        var component = CreateComponent<Game.SkillCardContainerComponent>(index);
        component.ContainerObject = newContainerObject;
        ReplaceComponent(index, component);
    }

    public void RemoveGameSkillCardContainer() {
        RemoveComponent(GameComponentsLookup.GameSkillCardContainer);
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

    static Entitas.IMatcher<GameEntity> _matcherGameSkillCardContainer;

    public static Entitas.IMatcher<GameEntity> GameSkillCardContainer {
        get {
            if(_matcherGameSkillCardContainer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameSkillCardContainer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameSkillCardContainer = matcher;
            }

            return _matcherGameSkillCardContainer;
        }
    }
}
