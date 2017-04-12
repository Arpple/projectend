using UnityEngine;
using System.Collections;
using Entitas;
using System;

public partial class UnitEntityFactory : EntityFactory<UnitEntity, UnitData>
{
	public UnitEntityFactory(IContext<UnitEntity> context) : base(context)
	{
	}

	protected override ComponentFactory<UnitEntity, UnitData> CreateComponentFactory(UnitEntity entity, UnitData data)
	{
		throw new NotImplementedException();
	}
}
