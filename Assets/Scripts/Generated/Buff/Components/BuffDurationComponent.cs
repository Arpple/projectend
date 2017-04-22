//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BuffEntity {

    public DurationComponent duration { get { return (DurationComponent)GetComponent(BuffComponentsLookup.Duration); } }
    public bool hasDuration { get { return HasComponent(BuffComponentsLookup.Duration); } }

    public void AddDuration(int newCount) {
        var index = BuffComponentsLookup.Duration;
        var component = CreateComponent<DurationComponent>(index);
        component.Count = newCount;
        AddComponent(index, component);
    }

    public void ReplaceDuration(int newCount) {
        var index = BuffComponentsLookup.Duration;
        var component = CreateComponent<DurationComponent>(index);
        component.Count = newCount;
        ReplaceComponent(index, component);
    }

    public void RemoveDuration() {
        RemoveComponent(BuffComponentsLookup.Duration);
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

    static Entitas.IMatcher<BuffEntity> _matcherDuration;

    public static Entitas.IMatcher<BuffEntity> Duration {
        get {
            if(_matcherDuration == null) {
                var matcher = (Entitas.Matcher<BuffEntity>)Entitas.Matcher<BuffEntity>.AllOf(BuffComponentsLookup.Duration);
                matcher.componentNames = BuffComponentsLookup.componentNames;
                _matcherDuration = matcher;
            }

            return _matcherDuration;
        }
    }
}