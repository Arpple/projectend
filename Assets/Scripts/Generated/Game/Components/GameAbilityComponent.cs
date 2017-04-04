//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.AbilityComponent ability { get { return (Game.AbilityComponent)GetComponent(GameComponentsLookup.Ability); } }
    public bool hasAbility { get { return HasComponent(GameComponentsLookup.Ability); } }

    public void AddAbility(string newAbilityClassName, Game.Ability newAbility) {
        var component = CreateComponent<Game.AbilityComponent>(GameComponentsLookup.Ability);
        component.AbilityClassName = newAbilityClassName;
        component.Ability = newAbility;
        AddComponent(GameComponentsLookup.Ability, component);
    }

    public void ReplaceAbility(string newAbilityClassName, Game.Ability newAbility) {
        var component = CreateComponent<Game.AbilityComponent>(GameComponentsLookup.Ability);
        component.AbilityClassName = newAbilityClassName;
        component.Ability = newAbility;
        ReplaceComponent(GameComponentsLookup.Ability, component);
    }

    public void RemoveAbility() {
        RemoveComponent(GameComponentsLookup.Ability);
    }
}
