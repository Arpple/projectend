//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Game.CardComponent card { get { return (Game.CardComponent)GetComponent(GameComponentsLookup.Card); } }
    public bool hasCard { get { return HasComponent(GameComponentsLookup.Card); } }

    public void AddCard(short newId, Game.Card newType) {
        var component = CreateComponent<Game.CardComponent>(GameComponentsLookup.Card);
        component.Id = newId;
        component.Type = newType;
        AddComponent(GameComponentsLookup.Card, component);
    }

    public void ReplaceCard(short newId, Game.Card newType) {
        var component = CreateComponent<Game.CardComponent>(GameComponentsLookup.Card);
        component.Id = newId;
        component.Type = newType;
        ReplaceComponent(GameComponentsLookup.Card, component);
    }

    public void RemoveCard() {
        RemoveComponent(GameComponentsLookup.Card);
    }
}
