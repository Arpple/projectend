using UnityEngine;
using UnityEngine.Events;

public class WeatherResolveExit : StateMachineBehaviour
{
	public UnityAction OnCompletedAction;

	public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
	{
		if(OnCompletedAction != null)
			OnCompletedAction();
	}
}
