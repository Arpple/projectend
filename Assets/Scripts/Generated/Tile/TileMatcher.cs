//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class TileMatcher {

    public static Entitas.IAllOfMatcher<TileEntity> AllOf(params int[] indices) {
        return Entitas.Matcher<TileEntity>.AllOf(indices);
    }

    public static Entitas.IAllOfMatcher<TileEntity> AllOf(params Entitas.IMatcher<TileEntity>[] matchers) {
          return Entitas.Matcher<TileEntity>.AllOf(matchers);
    }

    public static Entitas.IAnyOfMatcher<TileEntity> AnyOf(params int[] indices) {
          return Entitas.Matcher<TileEntity>.AnyOf(indices);
    }

    public static Entitas.IAnyOfMatcher<TileEntity> AnyOf(params Entitas.IMatcher<TileEntity>[] matchers) {
          return Entitas.Matcher<TileEntity>.AnyOf(matchers);
    }
}
