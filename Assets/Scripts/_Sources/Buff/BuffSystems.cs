public class BuffSystems : Feature
{
	public BuffSystems(Contexts contexts) : base("Buff")
	{
		Add(new BuffExpireSystem(contexts));
	}
}