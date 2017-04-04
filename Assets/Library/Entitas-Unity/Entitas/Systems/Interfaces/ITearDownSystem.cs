namespace Entitas {

    /// Implement this interface if you want to create a system which should
    /// tear down once in the 
    public interface ITearDownSystem : ISystem {

        void TearDown();
    }
}
