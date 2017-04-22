using UnityEngine;
using UnityEngine.Events;

public class AbilityEffect : MonoBehaviour
{
	public Animator Animation;
	public string AnimationName;

	private UnityAction _onAnimationEndAction;

	private void Start()
	{
		PlayAnimation();
	}

	public void PlayAnimation()
	{
		Animation.Play(AnimationName);
		Debug.Log("TEst");
	}

	public void PlayAnimation(string animation)
	{
		Animation.Play(animation);
	}

	public void PlayAnimationAndThen(UnityAction animationEndCallback)
	{
		PlayAnimation();
		_onAnimationEndAction = animationEndCallback;
	}

	public void PlayAnimationAndThen(string animation, UnityAction animationEndCallback)
	{
		PlayAnimation(animation);
		_onAnimationEndAction = animationEndCallback;
	}

	public void OnAnimationEnd()
	{
		if (_onAnimationEndAction != null)
		{
			_onAnimationEndAction();
			_onAnimationEndAction = null;
		}		
	}
}