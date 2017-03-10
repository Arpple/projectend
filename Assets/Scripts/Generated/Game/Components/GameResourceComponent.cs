//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public End.ResourceComponent resource { get { return (End.ResourceComponent)GetComponent(GameComponentsLookup.Resource); } }
    public bool hasResource { get { return HasComponent(GameComponentsLookup.Resource); } }

    public void AddResource(string newSpritePath) {
        var component = CreateComponent<End.ResourceComponent>(GameComponentsLookup.Resource);
        component.SpritePath = newSpritePath;
        AddComponent(GameComponentsLookup.Resource, component);
    }

    public void ReplaceResource(string newSpritePath) {
        var component = CreateComponent<End.ResourceComponent>(GameComponentsLookup.Resource);
        component.SpritePath = newSpritePath;
        ReplaceComponent(GameComponentsLookup.Resource, component);
    }

    public void RemoveResource() {
        RemoveComponent(GameComponentsLookup.Resource);
    }
}