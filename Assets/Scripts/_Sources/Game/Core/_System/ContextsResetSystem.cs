using System;
using Entitas;

namespace Game
{
	public class ContextsResetSystem : ITearDownSystem
	{
		readonly Contexts _contexts;

		public ContextsResetSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void TearDown()
		{
			foreach(var context in _contexts.allContexts)
			{
				context.Reset();
			}
		}
	}

}
