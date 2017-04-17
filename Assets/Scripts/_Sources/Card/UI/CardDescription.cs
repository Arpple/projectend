using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class CardDescription : MonoBehaviour
{
	public Text CardName;
	public Text CardDetail;

    [Header("Animator")]
    public Animator Animator;

    [Header("Button Panel")]
    public Animator ButtonGroup_Animator;
    private bool onShowPassive;
    public GameObject ButtonGroup;
    public Button ActiveButton;
    public Button PassiveButton;


    public void Init()
	{
		Assert.IsNotNull(CardName);
		Assert.IsNotNull(CardDetail);
        ShowActiveDescription();
	}

	public void SetDescription(CardObject card)
	{
		//TODO: get description string
		CardName.text = card.name;
		CardDetail.text = "Desc " + card.name;
        Animator.Play("SwapDescription");
    }

	public void ToggleVisibility()
	{
		gameObject.SetActive(!gameObject.activeSelf);
	}
    public void ReButtonOrder(string buttonName) {
        Transform b = ButtonGroup.transform.FindChild(buttonName);
        if(b != null) {
            b.transform.SetAsLastSibling();
        }
    }

    public void ShowActiveDescription() {
        if(onShowPassive) {
            ReButtonOrder(ActiveButton.name);
            ButtonGroup_Animator.Play("FocusActive");
            Animator.Play("SwapDescription");
        }
        onShowPassive = false;
    }

    public void ShowPassiveDescription() {
        if(!onShowPassive) {
            ReButtonOrder(PassiveButton.name);
            ButtonGroup_Animator.Play("FocusPassive");
            Animator.Play("SwapDescription");
        }
        onShowPassive = true;
    }

    public void ReorderButtonToTop(Button button) {
        button.transform.SetAsLastSibling();
    }
}