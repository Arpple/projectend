using Entitas;

[Game, Unit]
public class AbilityAttackComponent: IComponent {
    public int AttackPower;
    public int BlockCount;
    public bool canMakeDead;
}