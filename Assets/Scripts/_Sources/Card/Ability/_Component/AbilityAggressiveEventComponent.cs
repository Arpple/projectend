using Entitas;

[GameEvent, Unit]
public class AbilityAggressiveEventComponent : IComponent{

    public UnitEntity target;
    public int blockCount;
    public delegate void AbilityFunction();
    public AbilityFunction activeAbilityFunction;

    
}
