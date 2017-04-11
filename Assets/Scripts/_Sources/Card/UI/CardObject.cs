using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
	public Image MainImage;
    public Animator Animator;

	public CardEntity Entity
	{
		get { return (CardEntity)gameObject.GetEntityLink().entity; }
	}

	public void SetAbilityImage(Sprite sprite)
	{
		MainImage.sprite = sprite;
	}

	public void OnClick()
	{
		GameUI.Instance.OnCardClicked(this);
    }
        
    public void ShowHighlight() {
        this.Animator.Play("ShowHighlight");
    }

    public void HideHighlight() {
        this.Animator.Play("Idle");
    }
}