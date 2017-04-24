using Entitas;

[Game, Unit]
public class AbilityDamageComponent: IComponent {
    public int damage;
    public bool canMakeDead;
}