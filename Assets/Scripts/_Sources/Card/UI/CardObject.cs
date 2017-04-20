using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
	public Text CardNameText;
	public Text CardChargeText;
	public Image MainImage;
    public Image Highlight;
    public Animator Animator;

	public CardEntity Entity
	{
		get { return (CardEntity)gameObject.GetEntityLink().entity; }
	}

	public void SetCard(CardEntity card)
	{
		MainImage.sprite = card.sprite.Sprite;
		CardNameText.text = card.cardDescription.Name;
	}

	public void SetCharge(int charge)
	{
		CardChargeText.text = charge.ToString();
	}

	public void OnClick()
	{
		GameUI.Instance.OnCardClicked(this);
    }

    private bool _isFocus;

    void Update()
	{
        if(_isFocus)
		{
			Highlight.color = CardObjectsHightlightController.CurrentColor;
        }
    }

    public void ShowHighlight() {
        //Animator.Play("ShowHighlight");
        _isFocus = true;
        Highlight.gameObject.SetActive(true);
    }

    public void HideHighlight() {
        //Animator.Play("Idle");
        _isFocus = false;
        Highlight.gameObject.SetActive(false);
    }
}