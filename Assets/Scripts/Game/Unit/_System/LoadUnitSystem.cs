using System;
using System.Collections.Generic;
using Entitas;
using Entitas.Blueprints;

namespace End
{
	public abstract class LoadUnitSystem :LoadBlueprintSystem
	{
		public LoadUnitSystem(Contexts contexts)
			: base(contexts)
		{}
	}
}

