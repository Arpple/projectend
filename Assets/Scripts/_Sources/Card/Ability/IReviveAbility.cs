public interface IReviveAbility
{
	/// <summary>
	/// apply effect when entity dead
	/// </summary>
	/// <param name="deadEntity">The dead entity.</param>
	void OnDead(UnitEntity deadEntity);
}