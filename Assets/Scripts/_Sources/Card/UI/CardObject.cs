using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour
{
	public Image MainImage;
    public Image Highlight;
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

    private bool isFocus;
    private static Color highlightColor;

    void Update() {
        
        CardObject.highlightColor = Color.Lerp(
            new Color(1f, 0.855f, 0f, 0.627f)
            , new Color(1f, 0.855f, 0f, 0.137f)
            , Mathf.PingPong(Time.time, 1f));

        if(isFocus) {
            Debug.Log("Card ["+this.gameObject.name+"] on Focus...");
            this.Highlight.color = highlightColor;
        }
    }

    public void ShowHighlight() {
        //this.Animator.Play("ShowHighlight");
        Debug.Log("Show High");
        this.isFocus = true;
        this.Highlight.gameObject.SetActive(true);
    }

    public void HideHighlight() {
        //this.Animator.Play("Idle");
        this.isFocus = false;
        this.Highlight.gameObject.SetActive(false);
    }
}