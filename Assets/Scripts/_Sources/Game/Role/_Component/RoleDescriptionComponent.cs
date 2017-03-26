using Entitas;

namespace End.Game {
    public class RoleDescriptionComponent {
        [Game]
        public class DescriptionComponent: IComponent {
            public string Name;
            public string Description;
        }
    }
}
