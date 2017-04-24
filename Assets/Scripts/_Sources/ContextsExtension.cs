using Entitas.VisualDebugging.Unity;
using UnityEngine;

public static class ContextsExtension
{
	public static void ResetContextObserver(this Contexts contexts)
	{
		foreach(var context in contexts.allContexts)
		{
			Object.Destroy(context.FindContextObserver().gameObject);
		}
		contexts.InitializeContexObservers();
	}
}