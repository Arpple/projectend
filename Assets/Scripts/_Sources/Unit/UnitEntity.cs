using System.Collections.Generic;
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

	public void AddBuff(BuffEntity buff)
	{
		if(!hasBuffList)
		{
			AddBuffList(new List<BuffEntity>());
		}

		buffList.List.Add(buff);
		buff.AddTarget(this);
	}
}
