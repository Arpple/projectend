using Entitas;

namespace End.Game.Role {
    public class RoleDescriptionComponent {
        [Game]
        public class DescriptionComponent: IComponent {
            public string Name;
            public string Description;
        }
    }
}
