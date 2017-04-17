using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TurnNotification : MonoBehaviour
{
	public Text Turn, Player;
	public Animator AnimaControl;
	public UnityAction AnimationEndAction;

	public void Show(string turn, string playerName)
	{
		this.Turn.text = "Turn " + turn;
		this.Player.text = playerName;
		Play();
	}

	public void Play()
	{
		AnimaControl.Play("Show", -1, 0f);
	}

	public void OnAnimationEnd()
	{
		if(AnimationEndAction != null)
		{
			AnimationEndAction();
			AnimationEndAction = null;
		}
	}
}