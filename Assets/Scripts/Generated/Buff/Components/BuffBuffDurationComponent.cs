//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BuffEntity {

    public BuffDurationComponent buffDuration { get { return (BuffDurationComponent)GetComponent(BuffComponentsLookup.BuffDuration); } }
    public bool hasBuffDuration { get { return HasComponent(BuffComponentsLookup.BuffDuration); } }

    public void AddBuffDuration(int newCount) {
        var index = BuffComponentsLookup.BuffDuration;
        var component = CreateComponent<BuffDurationComponent>(index);
        component.Count = newCount;
        AddComponent(index, component);
    }

    public void ReplaceBuffDuration(int newCount) {
        var index = BuffComponentsLookup.BuffDuration;
        var component = CreateComponent<BuffDurationComponent>(index);
        component.Count = newCount;
        ReplaceComponent(index, component);
    }

    public void RemoveBuffDuration() {
        RemoveComponent(BuffComponentsLookup.BuffDuration);
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

    static Entitas.IMatcher<BuffEntity> _matcherBuffDuration;

    public static Entitas.IMatcher<BuffEntity> BuffDuration {
        get {
            if(_matcherBuffDuration == null) {
                var matcher = (Entitas.Matcher<BuffEntity>)Entitas.Matcher<BuffEntity>.AllOf(BuffComponentsLookup.BuffDuration);
                matcher.componentNames = BuffComponentsLookup.componentNames;
                _matcherBuffDuration = matcher;
            }

            return _matcherBuffDuration;
        }
    }
}
