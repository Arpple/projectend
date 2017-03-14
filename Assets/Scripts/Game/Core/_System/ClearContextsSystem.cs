using System;
using Entitas;

namespace End.Game
{
	public class ClearContextsSystem : ITearDownSystem
	{
		readonly Contexts _contexts;

		public ClearContextsSystem(Contexts contexts)
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
