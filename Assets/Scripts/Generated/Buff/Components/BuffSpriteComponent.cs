//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BuffEntity {

    public SpriteComponent sprite { get { return (SpriteComponent)GetComponent(BuffComponentsLookup.Sprite); } }
    public bool hasSprite { get { return HasComponent(BuffComponentsLookup.Sprite); } }

    public void AddSprite(UnityEngine.Sprite newSprite) {
        var index = BuffComponentsLookup.Sprite;
        var component = CreateComponent<SpriteComponent>(index);
        component.Sprite = newSprite;
        AddComponent(index, component);
    }

    public void ReplaceSprite(UnityEngine.Sprite newSprite) {
        var index = BuffComponentsLookup.Sprite;
        var component = CreateComponent<SpriteComponent>(index);
        component.Sprite = newSprite;
        ReplaceComponent(index, component);
    }

    public void RemoveSprite() {
        RemoveComponent(BuffComponentsLookup.Sprite);
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
public sealed partial class BuffMatcher {

    static Entitas.IMatcher<BuffEntity> _matcherSprite;

    public static Entitas.IMatcher<BuffEntity> Sprite {
        get {
            if(_matcherSprite == null) {
                var matcher = (Entitas.Matcher<BuffEntity>)Entitas.Matcher<BuffEntity>.AllOf(BuffComponentsLookup.Sprite);
                matcher.componentNames = BuffComponentsLookup.componentNames;
                _matcherSprite = matcher;
            }

            return _matcherSprite;
        }
    }
}
