//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly End.Game.InBoxComponent inBoxComponent = new End.Game.InBoxComponent();

    public bool isInBox {
        get { return HasComponent(GameComponentsLookup.InBox); }
        set {
            if(value != isInBox) {
                if(value) {
                    AddComponent(GameComponentsLookup.InBox, inBoxComponent);
                } else {
                    RemoveComponent(GameComponentsLookup.InBox);
                }
            }
        }
    }
}
