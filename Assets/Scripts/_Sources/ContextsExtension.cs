using Entitas.VisualDebugging.Unity;
using UnityEngine;

public static class ContextsExtension
{
	public static void ResetContextObserver(this Contexts contexts)
	{
#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
		foreach (var context in contexts.allContexts)
		{
			Object.Destroy(context.FindContextObserver().gameObject);
		}
		contexts.InitializeContexObservers();
#endif
	}
}