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

    /// <summary>
    /// Activate by Animation when Animation end
    /// !Please don't renamed or remove this method because animation will not found ; - ; )
    /// if do that please reset animation file (all file) 
    /// </summary>
	public void OnAnimationEnd()
	{
		if (_onAnimationEndAction != null)
		{
			_onAnimationEndAction();
			_onAnimationEndAction = null;
		}

        DestroyAnimation();
	}

    private void DestroyAnimation() {
        Object.Destroy(this.gameObject);
    }
}