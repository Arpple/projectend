//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentContextGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitContext {

    public UnitEntity gameLocalPlayerEntity { get { return GetGroup(UnitMatcher.GameLocalPlayer).GetSingleEntity(); } }

    public bool isGameLocalPlayer {
        get { return gameLocalPlayerEntity != null; }
        set {
            var entity = gameLocalPlayerEntity;
            if(value != (entity != null)) {
                if(value) {
                    CreateEntity().isGameLocalPlayer = true;
                } else {
                    DestroyEntity(entity);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    static readonly Game.LocalPlayerComponent gameLocalPlayerComponent = new Game.LocalPlayerComponent();

    public bool isGameLocalPlayer {
        get { return HasComponent(UnitComponentsLookup.GameLocalPlayer); }
        set {
            if(value != isGameLocalPlayer) {
                if(value) {
                    AddComponent(UnitComponentsLookup.GameLocalPlayer, gameLocalPlayerComponent);
                } else {
                    RemoveComponent(UnitComponentsLookup.GameLocalPlayer);
                }
            }
        }
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
public sealed partial class UnitMatcher {

    static Entitas.IMatcher<UnitEntity> _matcherGameLocalPlayer;

    public static Entitas.IMatcher<UnitEntity> GameLocalPlayer {
        get {
            if(_matcherGameLocalPlayer == null) {
                var matcher = (Entitas.Matcher<UnitEntity>)Entitas.Matcher<UnitEntity>.AllOf(UnitComponentsLookup.GameLocalPlayer);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherGameLocalPlayer = matcher;
            }

            return _matcherGameLocalPlayer;
        }
    }
}
