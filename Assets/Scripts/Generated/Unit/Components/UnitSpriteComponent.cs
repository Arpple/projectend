//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UnitEntity {

    public SpriteComponent sprite { get { return (SpriteComponent)GetComponent(UnitComponentsLookup.Sprite); } }
    public bool hasSprite { get { return HasComponent(UnitComponentsLookup.Sprite); } }

    public void AddSprite(UnityEngine.Sprite newSprite) {
        var index = UnitComponentsLookup.Sprite;
        var component = CreateComponent<SpriteComponent>(index);
        component.Sprite = newSprite;
        AddComponent(index, component);
    }

    public void ReplaceSprite(UnityEngine.Sprite newSprite) {
        var index = UnitComponentsLookup.Sprite;
        var component = CreateComponent<SpriteComponent>(index);
        component.Sprite = newSprite;
        ReplaceComponent(index, component);
    }

    public void RemoveSprite() {
        RemoveComponent(UnitComponentsLookup.Sprite);
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
public sealed partial class UnitMatcher {

    static Entitas.IMatcher<UnitEntity> _matcherSprite;

    public static Entitas.IMatcher<UnitEntity> Sprite {
        get {
            if(_matcherSprite == null) {
                var matcher = (Entitas.Matcher<UnitEntity>)Entitas.Matcher<UnitEntity>.AllOf(UnitComponentsLookup.Sprite);
                matcher.componentNames = UnitComponentsLookup.componentNames;
                _matcherSprite = matcher;
            }

            return _matcherSprite;
        }
    }
}
