using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game.Role.Component {
    public class RoleDescriptionComponent {
        [Game]
        public class DescriptionComponent: IComponent {
            public string Name;
            public string Description;
        }
    }
}
