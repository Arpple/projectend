//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class BuffEntity {

    static readonly BuffExhaustComponent buffExhaustComponent = new BuffExhaustComponent();

    public bool isBuffExhaust {
        get { return HasComponent(BuffComponentsLookup.BuffExhaust); }
        set {
            if(value != isBuffExhaust) {
                if(value) {
                    AddComponent(BuffComponentsLookup.BuffExhaust, buffExhaustComponent);
                } else {
                    RemoveComponent(BuffComponentsLookup.BuffExhaust);
                }
            }
        }
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

    static Entitas.IMatcher<BuffEntity> _matcherBuffExhaust;

    public static Entitas.IMatcher<BuffEntity> BuffExhaust {
        get {
            if(_matcherBuffExhaust == null) {
                var matcher = (Entitas.Matcher<BuffEntity>)Entitas.Matcher<BuffEntity>.AllOf(BuffComponentsLookup.BuffExhaust);
                matcher.componentNames = BuffComponentsLookup.componentNames;
                _matcherBuffExhaust = matcher;
            }

            return _matcherBuffExhaust;
        }
    }
}