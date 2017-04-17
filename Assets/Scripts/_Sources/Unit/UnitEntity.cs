using System.Linq;

public sealed partial class UnitEntity : Entitas.Entity
{
	public UnitEntity[] GetEntitiesInRange(int range, bool isIncludeSelf = false)
	{
		var entities = Contexts.sharedInstance.unit.GetEntities()
			.Where(m => m.mapPosition.GetDistance(this.mapPosition) <= range);

		return isIncludeSelf
			? entities.ToArray()
			: entities.Where(e => e != this).ToArray();
	}
}
